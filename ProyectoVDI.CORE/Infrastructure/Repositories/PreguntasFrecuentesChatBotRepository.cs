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
        public async Task CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {

            preguntasFrecuentesChatBot.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);

            await _context.PreguntasFrecuentesChatBot.AddAsync(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // Obtener todas
        public async Task<List<PreguntasFrecuentesChatBot>> GetAllAsync()
        {
            return await _context.PreguntasFrecuentesChatBot.ToListAsync();
        }

        // Update
        public async Task<PreguntasFrecuentesChatBot> GetByIdAsync(int id)
        {
            var result = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (result == null)
            {
                throw new InvalidOperationException($"No se encontró una pregunta frecuente con el ID {id}.");
            }
            return result;
        }

        // Obtener por pregunta (ignorando mayúsculas/minúsculas)
        public async Task<PreguntasFrecuentesChatBot?> GetByPreguntaAsync(string pregunta)
        {
            return await _context.PreguntasFrecuentesChatBot
                .FirstOrDefaultAsync(p => p.Pregunta.ToLower() == pregunta.ToLower());
        }

        // Actualizar pregunta
        public async Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            _context.PreguntasFrecuentesChatBot.Update(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // Eliminar por ID
        public async Task DeleteAsync(int id)
        {
            var pregunta = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (pregunta != null)
            {
                _context.PreguntasFrecuentesChatBot.Remove(pregunta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
