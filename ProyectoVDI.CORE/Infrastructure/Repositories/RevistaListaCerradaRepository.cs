using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistaListaCerradaRepository : IRevistaListaCerradaRepository
    {
        private readonly vdiContext _context;
        public RevistaListaCerradaRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevistaListaCerrada>> GetAllAsync()
        {
            return await _context.RevistaListaCerrada.ToListAsync();
        }

        public async Task<RevistaListaCerrada?> GetByIdAsync(int id)
        {
            return await _context.RevistaListaCerrada.FindAsync(id);
        }

        public async Task<int> CreateAsync(RevistaListaCerrada entity)
        {
            _context.RevistaListaCerrada.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRevista;
        }

        public async Task<bool> UpdateAsync(RevistaListaCerrada entity)
        {
            var existing = await _context.RevistaListaCerrada.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.RevistaListaCerrada.FindAsync(id);
            if (entity == null) return false;
            _context.RevistaListaCerrada.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
