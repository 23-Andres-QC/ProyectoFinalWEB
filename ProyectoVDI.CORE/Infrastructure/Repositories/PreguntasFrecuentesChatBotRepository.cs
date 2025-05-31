using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class PreguntasFrecuentesChatBotRepository : IPreguntasFrecuentesChatBotRepository
    {
        private readonly vdiContext _context;
        public PreguntasFrecuentesChatBotRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PreguntasFrecuentesChatBot>> GetAllAsync()
        {
            return await _context.PreguntasFrecuentesChatBot.ToListAsync();
        }

        public async Task<PreguntasFrecuentesChatBot?> GetByIdAsync(int id)
        {
            return await _context.PreguntasFrecuentesChatBot.FindAsync(id);
        }

        public async Task<int> CreateAsync(PreguntasFrecuentesChatBot entity)
        {
            entity.Estado = "Activo";
            entity.FechaCreacion = System.DateTime.Now;
            _context.PreguntasFrecuentesChatBot.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdPregunta;
        }

        public async Task<bool> UpdateAsync(PreguntasFrecuentesChatBot entity)
        {
            var existing = await _context.PreguntasFrecuentesChatBot.FindAsync(entity.IdPregunta);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PreguntasFrecuentesChatBot.FindAsync(id);
            if (entity == null) return false;
            entity.Estado = "Inactivo";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
