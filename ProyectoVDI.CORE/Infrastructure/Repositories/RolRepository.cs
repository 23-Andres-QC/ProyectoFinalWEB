using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
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
            return _context.Rol.ToList();
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        // GET BY ID
        public Rol GetById(int id)
        {
            return _context.Rol.FirstOrDefault(r => r.IdRol == id);
        }

        public async Task<Rol> GetByIdAsync(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        // CREATE
        public int Create(Rol item)
        {
            _context.Rol.Add(item);
            _context.SaveChanges();
            return item.IdRol;
        }

        public async Task<int> CreateAsync(Rol item)
        {
            await _context.Rol.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.IdRol;
        }

        // UPDATE
        public bool Update(Rol item)
        {
            var existing = _context.Rol.Find(item.IdRol);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Rol item)
        {
            var existing = await _context.Rol.FindAsync(item.IdRol);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public bool Delete(int id)
        {
            var item = _context.Rol.Find(id);
            if (item != null)
            {
                _context.Rol.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Rol.FindAsync(id);
            if (item != null)
            {
                _context.Rol.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
