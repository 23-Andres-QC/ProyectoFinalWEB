using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly vdiContext _context;

        public CategoriaRepository(vdiContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Categorias> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        // Get by ID
        public Categorias GetById(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.IdCategoria == id);
        }

        public async Task<Categorias> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        // Create
        public int Create(Categorias categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria.IdCategoria;
        }

        public async Task<int> CreateAsync(Categorias categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria.IdCategoria;
        }

        // Update
        public bool Update(Categorias categoria)
        {
            var existing = _context.Categorias.Find(categoria.IdCategoria);
            if (existing == null)
                return false;

            existing.Descripcion = categoria.Descripcion;
            existing.Estado = categoria.Estado;

            _context.Categorias.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Categorias categoria)
        {
            var existing = await _context.Categorias.FindAsync(categoria.IdCategoria);
            if (existing == null)
                return false;

            existing.Descripcion = categoria.Descripcion;
            existing.Estado = categoria.Estado;

            _context.Categorias.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete
        public bool Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}