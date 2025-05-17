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
    public class CalificacionChatBotRepository : ICalificacionChatBotRepository
    {
        private readonly vdiContext _context;
        public CalificacionChatBotRepository(vdiContext context)
        {
            _context = context;
        }
        // POST: create async CalificacionChatBot
        public async Task CreateAsync(CalificacionChatBot calificacionChatBot)
        {
            await _context.CalificacionChatBot.AddAsync(calificacionChatBot);
            await _context.SaveChangesAsync();
        }
        // Get all CalificacionChatBot
        public async Task<List<CalificacionChatBot>> GetAllAsync()
        {
            return await _context.CalificacionChatBot.ToListAsync();
        }
        // update async CalificacionChatBot
        public async Task UpdateAsync(CalificacionChatBot calificacionChatBot)
        {
            _context.CalificacionChatBot.Update(calificacionChatBot);
            await _context.SaveChangesAsync();
        }
        // delete async CalificacionChatBot
        public async Task DeleteAsync(int id)
        {
            var calificacionChatBot = await _context.CalificacionChatBot.FindAsync(id);
            if (calificacionChatBot != null)
            {
                _context.CalificacionChatBot.Remove(calificacionChatBot);
                await _context.SaveChangesAsync();
            }
        }
        // Get CalificacionChatBot by id
        public async Task<CalificacionChatBot> GetByIdAsync(int id)
        {
            return await _context.CalificacionChatBot.FindAsync(id);
        }

    }
}
