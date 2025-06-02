using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // Repositorio para la gestión de MetadatosRevistaIssn en la base de datos
    public class MetadatosRevistaIssnRepository : IMetadatosRevistaIssnRepository
    {
        // Contexto de base de datos inyectado por dependencia
        private readonly vdiContext _context;
        public MetadatosRevistaIssnRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtiene todos los registros para visualización en tabla
        public async Task<IEnumerable<MetadatosRevistaIssn>> GetAllAsync()
        {
            return await _context.MetadatosRevistaIssn.ToListAsync();
        }

        // Obtiene el detalle de un registro por su ID
        public async Task<MetadatosRevistaIssn?> GetByIdAsync(int id)
        {
            return await _context.MetadatosRevistaIssn.FindAsync(id);
        }

        // Crea un nuevo registro de MetadatosRevistaIssn
        public async Task<int> CreateAsync(MetadatosRevistaIssn entity)
        {
            _context.MetadatosRevistaIssn.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRevista;
        }

        // Actualiza un registro existente de MetadatosRevistaIssn
        public async Task<bool> UpdateAsync(MetadatosRevistaIssn entity)
        {
            var existing = await _context.MetadatosRevistaIssn.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // No se permite eliminar registros, por lo que no hay método DeleteAsync
    }
}
