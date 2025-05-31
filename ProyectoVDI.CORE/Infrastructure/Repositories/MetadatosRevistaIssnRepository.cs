using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MetadatosRevistaIssn.FindAsync(id);
            if (entity == null) return false;
            _context.MetadatosRevistaIssn.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
