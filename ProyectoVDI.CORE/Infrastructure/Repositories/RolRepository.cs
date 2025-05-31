using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly vdiContext _context;
        public RolRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        public async Task<int> CreateAsync(Rol entity)
        {
            entity.Estado = 1;
            _context.Rol.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRol;
        }

        public async Task<bool> UpdateAsync(Rol entity)
        {
            var existing = await _context.Rol.FindAsync(entity.IdRol);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Rol.FindAsync(id);
            if (entity == null) return false;
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
