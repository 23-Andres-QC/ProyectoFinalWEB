using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly vdiContext _context;

        public EditorialRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las editoriales
        public async Task<List<Editorial>> GetAllAsync()
        {
            return await _context.Editorial.ToListAsync();
        }

        // Obtener editorial por ID
        public async Task<Editorial?> GetByIdAsync(int id)
        {
            return await _context.Editorial.FindAsync(id);
        }

        // Crear nueva editorial
        public async Task<int> CreateAsync(Editorial editorial)
        {
            await _context.Editorial.AddAsync(editorial);
            await _context.SaveChangesAsync();
            return editorial.IdEditorial;
        }

        // Actualizar editorial existente
        public async Task UpdateAsync(Editorial editorial)
        {
            var existing = await _context.Editorial.FindAsync(editorial.IdEditorial);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la editorial con ID {editorial.IdEditorial} para actualizar.");
            }

            existing.IdRevista = editorial.IdRevista;
            existing.Mdpi = editorial.Mdpi;
            existing.Insights = editorial.Insights;
            existing.BeallSList = editorial.BeallSList;

            _context.Editorial.Update(existing);
            await _context.SaveChangesAsync();
        }

        // Eliminar editorial
        public async Task DeleteAsync(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                throw new InvalidOperationException($"No se encontró la editorial con ID {id} para eliminar.");
            }

            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();
        }
    }
}
