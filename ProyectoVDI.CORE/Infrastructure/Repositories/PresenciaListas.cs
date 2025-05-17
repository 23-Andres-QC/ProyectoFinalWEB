using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    internal class PresenciaEnListasRepository : IPresenciaEnListasRepository
    {
        private readonly vdiContext _context;

        public PresenciaEnListasRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PresenciaEnListas>> GetAllPresenciaEnListasAsync()
        {
            return await _context.PresenciaEnListas.ToListAsync();
        }

        public async Task<PresenciaEnListas?> GetPresenciaEnListasById(int id)
        {
            return await _context.PresenciaEnListas.FindAsync(id);
        }

        public async Task AddPresenciaEnListasAsync(PresenciaEnListas presencia)
        {
            await _context.PresenciaEnListas.AddAsync(presencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePresenciaEnListasAsync(PresenciaEnListas presencia)
        {
            _context.PresenciaEnListas.Update(presencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePresenciaEnListasAsync(int id)
        {
            var presencia = await GetPresenciaEnListasById(id);
            if (presencia != null)
            {
                _context.PresenciaEnListas.Remove(presencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}


