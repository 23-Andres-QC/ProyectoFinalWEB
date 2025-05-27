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
    public class PreguntasFrecuentesChatBotRepository : IPreguntasFrecuentesChatBotRepository
    {
        private readonly vdiContext _context;

        public PreguntasFrecuentesChatBotRepository(vdiContext context)
        {
            _context = context;
        }

        // Crear nueva pregunta frecuente
        public async Task<int> CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            preguntasFrecuentesChatBot.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            await _context.PreguntasFrecuentesChatBot.AddAsync(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
            return preguntasFrecuentesChatBot.IdPregunta;
        }

        // Obtener todas las preguntas frecuentes
        public async Task<List<PreguntasFrecuentesChatBot>> GetAllAsync()
        {
            return await _context.PreguntasFrecuentesChatBot.ToListAsync();
        }

        // Obtener por ID (devuelve null si no se encuentra)
        public async Task<PreguntasFrecuentesChatBot?> GetByIdAsync(int id)
        {
            return await _context.PreguntasFrecuentesChatBot.FindAsync(id);
        }

        // Actualizar una pregunta existente
        public async Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            var existing = await _context.PreguntasFrecuentesChatBot.FindAsync(preguntasFrecuentesChatBot.IdPregunta);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la pregunta frecuente con ID {preguntasFrecuentesChatBot.IdPregunta} para actualizar.");
            }
            _context.Entry(existing).CurrentValues.SetValues(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // Eliminar por ID (si existe)
        public async Task DeleteAsync(int id)
        {
            var pregunta = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (pregunta == null)
            {
                throw new InvalidOperationException($"No se encontró la pregunta frecuente con ID {id} para eliminar.");
            }
            _context.PreguntasFrecuentesChatBot.Remove(pregunta);
            await _context.SaveChangesAsync();
        }
    }
}
