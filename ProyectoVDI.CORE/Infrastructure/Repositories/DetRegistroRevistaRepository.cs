using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class DetRegistroRevistaRepository : IDetRegistroRevistaRepository
    {
        private readonly vdiContext _context;
        public DetRegistroRevistaRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetRegistroRevista>> GetAllAsync()
        {
            return await _context.DetRegistroRevista.ToListAsync();
        }

        public async Task<DetRegistroRevista?> GetByIdAsync(int id)
        {
            return await _context.DetRegistroRevista.FindAsync(id);
        }

        public async Task<int> CreateAsync(DetRegistroRevista entity)
        {
            _context.DetRegistroRevista.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdDetalle;
        }

        public async Task<bool> UpdateAsync(DetRegistroRevista entity)
        {
            var existing = await _context.DetRegistroRevista.FindAsync(entity.IdDetalle);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DetRegistroRevista.FindAsync(id);
            if (entity == null) return false;
            _context.DetRegistroRevista.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
