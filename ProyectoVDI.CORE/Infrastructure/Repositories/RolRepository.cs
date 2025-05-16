using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Entities;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RolRepository
    {
        private readonly vdiContext _context;

        public RolRepository(vdiContext context)
        {
            _context = context;
        }

        // GET ALL
        public IEnumerable<Rol> GetAll()
        {
            return _context.Roles.ToList();
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET BY ID
        public Rol GetById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.IdRol == id);
        }

        public async Task<Rol> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        // CREATE
        public int Create(Rol rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
            return rol.IdRol;
        }

        public async Task<int> CreateAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol.IdRol;
        }

        // UPDATE
        public bool Update(Rol rol)
        {
            var existing = _context.Roles.Find(rol.IdRol);
            if (existing == null) return false;

            existing.Descripcion = rol.Descripcion;
            _context.Roles.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Rol rol)
        {
            var existing = await _context.Roles.FindAsync(rol.IdRol);
            if (existing == null) return false;

            existing.Descripcion = rol.Descripcion;
            _context.Roles.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public bool Delete(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
