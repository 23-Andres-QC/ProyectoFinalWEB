using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // Repositorio para la entidad Usuario, implementa IUsuariosRepository
    public class UsuariosRepository : IUsuariosRepository
    {
        // Contexto de base de datos inyectado
        private readonly vdiContext _context;

        // Constructor que recibe el contexto
        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtiene todos los usuarios activos (Estado == 1)
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario
                .Where(u => u.Estado == 1)
                .ToListAsync();
        }

        // Obtiene un usuario activo por su ID
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario
                .Where(u => u.IdUsuario == id && u.Estado == 1)
                .FirstOrDefaultAsync();
        }

        // Crea un nuevo usuario, lo marca como activo y asigna la fecha de creación
        public async Task<int> CreateAsync(Usuario usuario)
        {
            usuario.Estado = 1;
            usuario.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            usuario.FechaModificacion = null;
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.IdUsuario;
        }

        // Actualiza los datos de un usuario existente y asigna la fecha de modificación
        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuario.FindAsync(usuario.IdUsuario);
            if (existingUsuario == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {usuario.IdUsuario} para actualizar.");
            }
            existingUsuario.Correo = usuario.Correo;
            existingUsuario.Contraseña = usuario.Contraseña;
            existingUsuario.IdRol = usuario.IdRol;
            existingUsuario.Estado = usuario.Estado;
            existingUsuario.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            _context.Usuario.Update(existingUsuario);
            await _context.SaveChangesAsync();
        }

        // Realiza un "soft delete" cambiando Estado a 0 y actualiza la fecha de modificación
        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {id} para eliminar.");
            }
            usuario.Estado = 0; // Soft delete
            usuario.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
