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
    public class MetadatosRevistaIssnRepository : IMetadatosRevistaIssnRepository
    {
        private readonly vdiContext _context;
        public MetadatosRevistaIssnRepository(vdiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MetadatosRevistaIssn>> GetAllAsync()
        {
            return await _context.MetadatosRevistaIssn.ToListAsync();
        }

        public async Task<MetadatosRevistaIssn?> GetByIdAsync(int id)
        {
            return await _context.MetadatosRevistaIssn.FindAsync(id);
        }

        public async Task<int> CreateAsync(MetadatosRevistaIssn entity)
        {
            _context.MetadatosRevistaIssn.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRevista;
        }

        public async Task<bool> UpdateAsync(MetadatosRevistaIssn entity)
        {
            var existing = await _context.MetadatosRevistaIssn.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // NUEVO: Obtener nombres de columnas reales de la tabla (usando EF Core Model)
        public Task<IEnumerable<string>> GetColumnNamesAsync()
        {
            var excluded = new HashSet<string> { "Id_Revista" };
            var entityType = _context.Model.FindEntityType(typeof(MetadatosRevistaIssn));
            var columns = entityType.GetProperties()
                .Select(p => p.GetColumnName())
                .Where(n => n != null && !excluded.Contains(n))
                .ToList();
            return Task.FromResult(columns.AsEnumerable());
        }

        // NUEVO: Obtener valores distintos de una columna (usando nombre de columna real)
        public async Task<IEnumerable<string>> GetDistinctValuesAsync(string columnName)
        {
            var entityType = _context.Model.FindEntityType(typeof(MetadatosRevistaIssn));
            var prop = entityType.GetProperties().FirstOrDefault(p => p.GetColumnName().Equals(columnName, System.StringComparison.OrdinalIgnoreCase));
            if (prop == null) return Enumerable.Empty<string>();
            var propName = prop.Name;
            var all = await _context.MetadatosRevistaIssn.ToListAsync();
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
