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
        public async Task<int> CreateAsync(Rol rol)
        {
            await _context.Rol.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol.IdRol;
        }

        // Obtener todos los roles
        public async Task<List<Rol>> GetAllAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        // Obtener rol por ID (devuelve null si no existe)
        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        // Actualizar rol
        public async Task UpdateAsync(Rol rol)
        {
            var existing = await _context.Rol.FindAsync(rol.IdRol);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró el rol con ID {rol.IdRol} para actualizar.");
            }
            existing.Descripcion = rol.Descripcion;
            _context.Rol.Update(existing);
            await _context.SaveChangesAsync();
        }

        // Eliminar rol por ID
        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                throw new InvalidOperationException($"No se encontró el rol con ID {id} para eliminar.");
            }
            _context.Rol.Remove(rol);
            await _context.SaveChangesAsync();
        }
    }
}
