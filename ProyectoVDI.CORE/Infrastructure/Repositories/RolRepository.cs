using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly vdiContext _context;

        public RolRepository(vdiContext context)
        {
            _context = context;
        }

        // Crear nuevo rol
        public async Task CreateAsync(Rol rol)
        {
            await _context.Rol.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los roles
        public async Task<List<Rol>> GetAllAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        // Obtener rol por ID (lanzando excepción si no existe)
        public async Task<Rol> GetByIdAsync(int id)
        {
            var result = await _context.Rol.FindAsync(id);
            if (result == null)
            {
                throw new InvalidOperationException($"No se encontró un rol con el ID {id}.");
            }
            return result;
        }

        // Actualizar rol
        public async Task UpdateAsync(Rol rol)
        {
            _context.Rol.Update(rol);
            await _context.SaveChangesAsync();
        }

        // Eliminar rol por ID
        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
