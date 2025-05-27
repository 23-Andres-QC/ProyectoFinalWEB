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
    public class CalificacionChatBotRepository : ICalificacionChatBotRepository
    {
        private readonly vdiContext _context;

        public CalificacionChatBotRepository(vdiContext context)
        {
            _context = context;
        }

        // Crear una nueva calificación con fecha automática
        public async Task<int> CreateAsync(CalificacionChatBot calificacionChatBot)
        {
            // Asigna automáticamente fecha
            calificacionChatBot.FechaHora = DateTime.Now;

            await _context.CalificacionChatBot.AddAsync(calificacionChatBot);
            await _context.SaveChangesAsync();
            return calificacionChatBot.IdFeedback;
        }

        // Obtener todas las calificaciones
        public async Task<List<CalificacionChatBot>> GetAllAsync()
        {
            return await _context.CalificacionChatBot.ToListAsync();
        }

        // Updated method to handle possible null return value
        public async Task<CalificacionChatBot?> GetByIdAsync(int id)
        {
            return await _context.CalificacionChatBot.FindAsync(id);
        }

        // Actualizar
        public async Task UpdateAsync(CalificacionChatBot calificacionChatBot)
        {
            var existing = await _context.CalificacionChatBot.FindAsync(calificacionChatBot.IdFeedback);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la calificación con ID {calificacionChatBot.IdFeedback} para actualizar.");
            }
            _context.Entry(existing).CurrentValues.SetValues(calificacionChatBot);
            await _context.SaveChangesAsync();
        }

        // Eliminar
        public async Task DeleteAsync(int id)
        {
            var calificacion = await _context.CalificacionChatBot.FindAsync(id);
            if (calificacion == null)
            {
                throw new InvalidOperationException($"No se encontró la calificación con ID {id} para eliminar.");
            }
            _context.CalificacionChatBot.Remove(calificacion);
            await _context.SaveChangesAsync();
        }
    }
}
