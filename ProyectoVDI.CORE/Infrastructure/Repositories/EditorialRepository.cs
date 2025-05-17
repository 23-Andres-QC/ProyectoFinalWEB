using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
//a
namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly vdiContext _context;

        public EditorialRepository(vdiContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Editorial> GetAll()
        {
            return _context.Editorial.ToList();
        }

        public async Task<IEnumerable<Editorial>> GetAllAsync()
        {
            return await _context.Editorial.ToListAsync();
        }

        // Get by ID
        public Editorial GetById(int id)
        {
            return _context.Editorial.FirstOrDefault(e => e.IdEditorial == id);
        }

        public async Task<Editorial> GetByIdAsync(int id)
        {
            return await _context.Editorial.FindAsync(id);
        }

        // Create
        public int Create(Editorial editorial)
        {
            _context.Editorial.Add(editorial);
            _context.SaveChanges();
            return editorial.IdEditorial;
        }

        public async Task<int> CreateAsync(Editorial editorial)
        {
            await _context.Editorial.AddAsync(editorial);
            await _context.SaveChangesAsync();
            return editorial.IdEditorial;
        }

        // Update
        public bool Update(Editorial editorial)
        {
            var existing = _context.Editorial.Find(editorial.IdEditorial);
            if (existing == null)
                return false;

            existing.Mdpi = editorial.Mdpi;
            existing.Insights = editorial.Insights;
            existing.BeallSList = editorial.BeallSList;
            existing.IdRevista = editorial.IdRevista;

            _context.Editorial.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Editorial editorial)
        {
            var existing = await _context.Editorial.FindAsync(editorial.IdEditorial);
            if (existing == null)
                return false;

            existing.Mdpi = editorial.Mdpi;
            existing.Insights = editorial.Insights;
            existing.BeallSList = editorial.BeallSList;
            existing.IdRevista = editorial.IdRevista;

            _context.Editorial.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete
        public bool Delete(int id)
        {
            var editorial = _context.Editorial.Find(id);
            if (editorial != null)
            {
                _context.Editorial.Remove(editorial);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial != null)
            {
                _context.Editorial.Remove(editorial);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}