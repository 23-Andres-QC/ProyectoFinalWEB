using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class IssnsRevistaRepository : IIssnsRevistaRepository
    {
        private readonly vdiContext _context;
        public IssnsRevistaRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssnsRevista>> GetAllAsync()
        {
            return await _context.IssnsRevista.ToListAsync();
        }

        public async Task<IssnsRevista?> GetByIdAsync(int id)
        {
            return await _context.IssnsRevista.FindAsync(id);
        }

        public async Task<int> CreateAsync(IssnsRevista entity)
        {
            _context.IssnsRevista.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdIssn;
        }

        public async Task<bool> UpdateAsync(IssnsRevista entity)
        {
            var existing = await _context.IssnsRevista.FindAsync(entity.IdIssn);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.IssnsRevista.FindAsync(id);
            if (entity == null) return false;
            _context.IssnsRevista.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
