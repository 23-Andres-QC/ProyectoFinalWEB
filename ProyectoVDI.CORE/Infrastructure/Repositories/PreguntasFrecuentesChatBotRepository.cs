using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // POST: create async PreguntasFrecuentesChatBot
        public async Task CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            await _context.PreguntasFrecuentesChatBot.AddAsync(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }


        // Get all PreguntasFrecuentesChatBot
        public async Task<List<PreguntasFrecuentesChatBot>> GetAllAsync()
        {
            return await _context.PreguntasFrecuentesChatBot.ToListAsync();
        }

        // update async PreguntasFrecuentesChatBot
        public async Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            _context.PreguntasFrecuentesChatBot.Update(preguntasFrecuentesChatBot);
            await _context.SaveChangesAsync();
        }

        // delete async PreguntasFrecuentesChatBot
        public async Task DeleteAsync(int id)
        {
            var preguntasFrecuentesChatBot = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (preguntasFrecuentesChatBot != null)
            {
                _context.PreguntasFrecuentesChatBot.Remove(preguntasFrecuentesChatBot);
                await _context.SaveChangesAsync();
            }
        }

        // Get PreguntasFrecuentesChatBot by id
        public async Task<PreguntasFrecuentesChatBot> GetByIdAsync(int id)
        {
            return await _context.PreguntasFrecuentesChatBot.FindAsync(id);
        }

        // Get PreguntasFrecuentesChatBot by pregunta
        public async Task<PreguntasFrecuentesChatBot> GetByPreguntaAsync(string pregunta)
        {
            return await _context.PreguntasFrecuentesChatBot
                .FirstOrDefaultAsync(p => p.Pregunta.Equals(pregunta, StringComparison.OrdinalIgnoreCase));
        }




    }
}
