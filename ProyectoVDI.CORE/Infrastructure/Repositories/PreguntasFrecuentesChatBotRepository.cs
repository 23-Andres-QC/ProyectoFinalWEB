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
            // Asignar la fecha actual si no se especifica
            preguntasFrecuentesChatBot.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);

            await _context.PreguntasFrecuentesChatBot.AddAsync(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // Obtener todas las preguntas frecuentes
        public async Task<List<PreguntasFrecuentesChatBot>> GetAllAsync()
        {
            return await _context.PreguntasFrecuentesChatBot.ToListAsync();
        }

        // Obtener por ID (lanzando excepción si no se encuentra)
        public async Task<PreguntasFrecuentesChatBot> GetByIdAsync(int id)
        {
            var result = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (result == null)
            {
                throw new InvalidOperationException($"No se encontró una pregunta frecuente con el ID {id}.");
            }
            return result;
        }


        // Actualizar una pregunta existente
        public async Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            _context.PreguntasFrecuentesChatBot.Update(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // Eliminar por ID (si existe)
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
