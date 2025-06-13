using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistaListaCerradaRepository : IRevistaListaCerradaRepository
    {
        private readonly vdiContext _context;
        public RevistaListaCerradaRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevistaListaCerrada>> GetAllAsync()
        {
            return await _context.RevistaListaCerrada.ToListAsync();
        }

        public async Task<RevistaListaCerrada?> CreateListaCerrada(RevistaListaCerrada entity)
        {
            if (entity == null) return null;

            await _context.RevistaListaCerrada.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(RevistaListaCerrada entity)
        {
            var existing = await _context.RevistaListaCerrada.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RevistaListaCerrada?> GetByNombreAsync(string nombre)
        {
            return await _context.RevistaListaCerrada.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.RevistaListaCerrada.FindAsync(id);
            if (entity == null) return false;
            _context.RevistaListaCerrada.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // NUEVO: Obtener nombres de columnas reales de la tabla (usando EF Core Model)
        public Task<IEnumerable<string>> GetColumnNamesAsync()
        {
            var excluded = new HashSet<string> { "Nombre", "IncentivoUSD", "Id_Revista" };
            var entityType = _context.Model.FindEntityType(typeof(RevistaListaCerrada));
            var columns = entityType.GetProperties()
                .Select(p => p.GetColumnName())
                .Where(n => n != null && !excluded.Contains(n))
                .ToList();
            return Task.FromResult(columns.AsEnumerable());
        }

        // NUEVO: Obtener valores distintos de una columna (usando nombre de columna real)
        public async Task<IEnumerable<string>> GetDistinctValuesAsync(string columnName)
        {
            var entityType = _context.Model.FindEntityType(typeof(RevistaListaCerrada));
            var prop = entityType.GetProperties().FirstOrDefault(p => p.GetColumnName().Equals(columnName, System.StringComparison.OrdinalIgnoreCase));
            if (prop == null) return Enumerable.Empty<string>();
            var propName = prop.Name;
            var all = await _context.RevistaListaCerrada.ToListAsync();
            var values = all.Select(x => {
                var val = x.GetType().GetProperty(propName)?.GetValue(x);
                return val?.ToString();
            })
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .ToList();
            return values;
        }
    }
}
