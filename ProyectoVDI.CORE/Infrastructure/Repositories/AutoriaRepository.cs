using System;
using System.Collections.Generic;
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

        // Obtener todas las autorías
        public async Task<List<Autoria>> GetAllAsync()
        {
            return await _context.Autoria.ToListAsync();
        }

        // Updated method to handle possible null return value
        public async Task<Autoria?> GetByIdAsync(int id)
        {
            return await _context.Autoria.FindAsync(id);
        }

        // Crear nueva autoría
        public async Task<int> CreateAsync(Autoria autoria)
        {
            // No hay Estado ni Fecha en Autoria
            await _context.Autoria.AddAsync(autoria);
            await _context.SaveChangesAsync();
            return autoria.IdAutoria;
        }

        // Actualizar autoría existente
        public async Task UpdateAsync(Autoria autoria)
        {
            var existing = await _context.Autoria.FindAsync(autoria.IdAutoria);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la autoría con ID {autoria.IdAutoria} para actualizar.");
            }

            existing.IdRevista = autoria.IdRevista;
            existing.CoautoriaEsan = autoria.CoautoriaEsan;
            existing.PosiciónDelAutor = autoria.PosiciónDelAutor;

            _context.Autoria.Update(existing);
            await _context.SaveChangesAsync();
        }

        // Eliminar autoría por ID
        public async Task DeleteAsync(int id)
        {
            var autoria = await _context.Autoria.FindAsync(id);
            if (autoria == null)
            {
                throw new InvalidOperationException($"No se encontró la autoría con ID {id} para eliminar.");
            }

            _context.Autoria.Remove(autoria);
            await _context.SaveChangesAsync();
        }
    }
}
