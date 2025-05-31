using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly vdiContext _context;
        public UsuarioRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<int> CreateAsync(Usuario entity)
        {
            entity.Estado = 1;
            entity.FechaCreacion = System.DateTime.Now;
            _context.Usuario.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdUsuario;
        }

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            var existing = await _context.Usuario.FindAsync(entity.IdUsuario);
            if (existing == null) return false;
            entity.FechaModificacion = System.DateTime.Now;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Usuario.FindAsync(id);
            if (entity == null) return false;
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
