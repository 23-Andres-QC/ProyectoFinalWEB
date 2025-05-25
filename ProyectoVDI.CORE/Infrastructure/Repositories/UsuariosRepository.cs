using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly vdiContext _context;

        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario
                .Where(u => u.Estado == 1)
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario
                .Where(u => u.IdUsuario == id && u.Estado == 1)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.IdUsuario;
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuario.FindAsync(usuario.IdUsuario);
            if (existingUsuario != null)
            {
                existingUsuario.Correo = usuario.Correo;
                existingUsuario.Contraseña = usuario.Contraseña;
                existingUsuario.IdRol = usuario.IdRol;
                existingUsuario.Estado = usuario.Estado;
                existingUsuario.FechaModificacion = usuario.FechaModificacion;

                _context.Usuario.Update(existingUsuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                usuario.Estado = 0; // Soft delete
                usuario.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);

                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
