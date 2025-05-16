using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Entities;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistasIndexavionRepository
    {
        private readonly vdiContext _context;

        public RevistasIndexavionRepository(vdiContext context)
        {
            _context = context;
        }

        // GET ALL
        public IEnumerable<RevistaIndexacion> GetAll()
        {
            return _context.RevistaIndexaciones.ToList();
        }

        public async Task<IEnumerable<RevistaIndexacion>> GetAllAsync()
        {
            return await _context.RevistaIndexaciones.ToListAsync();
        }

        // GET BY ID
        public RevistaIndexacion GetById(int id)
        {
            return _context.RevistaIndexaciones.FirstOrDefault(r => r.IdIndexacion == id);
        }

        public async Task<RevistaIndexacion> GetByIdAsync(int id)
        {
            return await _context.RevistaIndexaciones.FindAsync(id);
        }

        // CREATE
        public int Create(RevistaIndexacion item)
        {
            _context.RevistaIndexaciones.Add(item);
            _context.SaveChanges();
            return item.IdIndexacion;
        }

        public async Task<int> CreateAsync(RevistaIndexacion item)
        {
            await _context.RevistaIndexaciones.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.IdIndexacion;
        }

        // UPDATE
        public bool Update(RevistaIndexacion item)
        {
            var existing = _context.RevistaIndexaciones.Find(item.IdIndexacion);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(RevistaIndexacion item)
        {
            var existing = await _context.RevistaIndexaciones.FindAsync(item.IdIndexacion);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public bool Delete(int id)
        {
            var item = _context.RevistaIndexaciones.Find(id);
            if (item != null)
            {
                _context.RevistaIndexaciones.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.RevistaIndexaciones.FindAsync(id);
            if (item != null)
            {
                _context.RevistaIndexaciones.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
