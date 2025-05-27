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

        // Crear una nueva calificación 
        public async Task CreateAsync(CalificacionChatBot calificacionChatBot)
        {
            await _context.CalificacionChatBot.AddAsync(calificacionChatBot);
            await _context.SaveChangesAsync();
        }




        // Obtener todas las calificaciones
        public async Task<List<CalificacionChatBot>> GetAllAsync()
        {
            return await _context.CalificacionChatBot.ToListAsync();
        }

    }
}
