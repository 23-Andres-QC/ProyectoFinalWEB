using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistasIndexacionRepository : IRevistasIndexacionRepository
    {
        private readonly vdiContext _context;

        public RevistasIndexacionRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las indexaciones
        public async Task<List<RevistaIndexacion>> GetAllAsync()
        {
            return await _context.RevistaIndexacion
                .Include(r => r.IdRevistaNavigation) // si necesitas incluir los datos de la revista
                .ToListAsync();
        }

        // Obtener indexación por ID
        public async Task<RevistaIndexacion?> GetByIdAsync(int id)
        {
            return await _context.RevistaIndexacion
                .Include(r => r.IdRevistaNavigation)
                .FirstOrDefaultAsync(r => r.IdIndexacion == id);
        }

        // Crear nueva indexación
        public async Task<int> CreateAsync(RevistaIndexacion item)
        {
            await _context.RevistaIndexacion.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.IdIndexacion;
        }

        // Actualizar indexación existente
        public async Task UpdateAsync(RevistaIndexacion item)
        {
            var existing = await _context.RevistaIndexacion.FindAsync(item.IdIndexacion);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la indexación con ID {item.IdIndexacion} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }

        // Eliminar indexación por ID
        public async Task DeleteAsync(int id)
        {
            var item = await _context.RevistaIndexacion.FindAsync(id);
            if (item == null)
            {
                throw new InvalidOperationException($"No se encontró la indexación con ID {id} para eliminar.");
            }

            _context.RevistaIndexacion.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
