using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly vdiContext _context;

        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        // Obtener usuario por ID
        public async Task<Usuario> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {id}.");
            }
            return usuario;
        }

        // Crear nuevo usuario
        public async Task<int> CreateAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.IdUsuario;
        }

        // Actualizar usuario existente
        public async Task UpdateAsync(Usuario usuario)
        {
            var existing = await _context.Usuario.FindAsync(usuario.IdUsuario);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {usuario.IdUsuario} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
        }

        // Eliminar usuario por ID
        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException($"No se encontró el usuario con ID {id} para eliminar.");
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
