using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // =====================
    // Repositorio para la gestión de usuarios
    // =====================
    public class UsuariosRepository : IUsuariosRepository
    {
        // Contexto de base de datos inyectado
        private readonly vdiContext _context;

        // Constructor
        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }

        // =====================
        // Obtiene todos los usuarios (sin filtrar por Estado)
        // =====================
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario
                .Include(u => u.IdProfesorNavigation)
                .ToListAsync();
        }

        // =====================
        // Obtiene un usuario por su ID (sin filtrar por Estado)
        // =====================
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario
                .Where(u => u.IdUsuario == id)
                .Include(u => u.IdProfesorNavigation)
                .FirstOrDefaultAsync();
        }

        // =====================
        // Crea un nuevo usuario
        // =====================
        public async Task<int> CreateAsync(Usuario usuario)
        {
            usuario.Estado = 1;
            usuario.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            usuario.FechaModificacion = null;
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.IdUsuario;
        }

        // =====================
        // Actualiza un usuario existente
        // =====================
        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuario.FindAsync(usuario.IdUsuario);
            if (existingUsuario == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {usuario.IdUsuario} para actualizar.");
            }
            existingUsuario.IdProfesor = usuario.IdProfesor;
            existingUsuario.Correo = usuario.Correo;
            existingUsuario.Contraseña = usuario.Contraseña;
            existingUsuario.IdRol = usuario.IdRol;
            // Estado ya no se actualiza desde el servicio
            existingUsuario.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            _context.Usuario.Update(existingUsuario);
            await _context.SaveChangesAsync();
        }

        // =====================
        // Elimina (soft delete) un usuario por su ID
        // =====================
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