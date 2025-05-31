using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class CalificacionChatBotRepository : ICalificacionChatBotRepository
    {
        private readonly vdiContext _context;
        public CalificacionChatBotRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CalificacionChatBot>> GetAllAsync()
        {
            return await _context.CalificacionChatBot.ToListAsync();
        }

        public async Task<CalificacionChatBot?> GetByIdAsync(int id)
        {
            return await _context.CalificacionChatBot.FindAsync(id);
        }

        public async Task<int> CreateAsync(CalificacionChatBot entity)
        {
            entity.Fecha = System.DateTime.Now;
            _context.CalificacionChatBot.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdFeedback;
        }

        public async Task<bool> UpdateAsync(CalificacionChatBot entity)
        {
            var existing = await _context.CalificacionChatBot.FindAsync(entity.IdFeedback);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CalificacionChatBot.FindAsync(id);
            if (entity == null) return false;
            _context.CalificacionChatBot.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
