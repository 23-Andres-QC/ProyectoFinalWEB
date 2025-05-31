using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RegistroRevistasRepository : IRegistroRevistasRepository
    {
        private readonly vdiContext _context;
        public RegistroRevistasRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistroRevistas>> GetAllAsync()
        {
            return await _context.RegistroRevistas.ToListAsync();
        }

        public async Task<RegistroRevistas?> GetByIdAsync(int id)
        {
            return await _context.RegistroRevistas.FindAsync(id);
        }

        public async Task<int> CreateAsync(RegistroRevistas entity)
        {
            entity.FechaRegistro = System.DateTime.Now;
            _context.RegistroRevistas.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRegistro;
        }

        public async Task<bool> UpdateAsync(RegistroRevistas entity)
        {
            var existing = await _context.RegistroRevistas.FindAsync(entity.IdRegistro);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.RegistroRevistas.FindAsync(id);
            if (entity == null) return false;
            _context.RegistroRevistas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
