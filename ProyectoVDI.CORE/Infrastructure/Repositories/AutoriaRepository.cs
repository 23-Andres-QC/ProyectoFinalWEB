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
    public class AutoriaRepository : IAutoriaRepository
    {
        private readonly vdiContext _context;

        public AutoriaRepository(vdiContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Autoria> GetAll()
        {
            return _context.Autoria.ToList();
        }

        public async Task<IEnumerable<Autoria>> GetAllAsync()
        {
            return await _context.Autoria.ToListAsync();
        }

        // Get by ID
        public Autoria GetById(int id)
        {
            return _context.Autoria.FirstOrDefault(a => a.IdAutoria == id);
        }

        public async Task<Autoria> GetByIdAsync(int id)
        {
            return await _context.Autoria.FindAsync(id);
        }

        // Create
        public int Create(Autoria autoria)
        {
            _context.Autoria.Add(autoria);
            _context.SaveChanges();
            return autoria.IdAutoria;
        }

        public async Task<int> CreateAsync(Autoria autoria)
        {
            await _context.Autoria.AddAsync(autoria);
            await _context.SaveChangesAsync();
            return autoria.IdAutoria;
        }

        // Update
        public bool Update(Autoria autoria)
        {
            var existing = _context.Autoria.Find(autoria.IdAutoria);
            if (existing == null)
                return false;

            existing.IdRevista = autoria.IdRevista;
            existing.CoautoriaEsan = autoria.CoautoriaEsan;
            existing.PosiciónDelAutor = autoria.PosiciónDelAutor;

            _context.Autoria.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Autoria autoria)
        {
            var existing = await _context.Autoria.FindAsync(autoria.IdAutoria);
            if (existing == null)
                return false;

            existing.IdRevista = autoria.IdRevista;
            existing.CoautoriaEsan = autoria.CoautoriaEsan;
            existing.PosiciónDelAutor = autoria.PosiciónDelAutor;

            _context.Autoria.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete
        public bool Delete(int id)
        {
            var autoria = _context.Autoria.Find(id);
            if (autoria != null)
            {
                _context.Autoria.Remove(autoria);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var autoria = await _context.Autoria.FindAsync(id);
            if (autoria != null)
            {
                _context.Autoria.Remove(autoria);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}