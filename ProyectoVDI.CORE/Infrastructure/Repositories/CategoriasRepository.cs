using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly vdiContext _context;
        public CategoriasRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categorias?> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<int> CreateAsync(Categorias entity)
        {
            entity.Estado = 1;
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdCategoria;
        }

        public async Task<bool> UpdateAsync(Categorias entity)
        {
            var existing = await _context.Categorias.FindAsync(entity.IdCategoria);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Categorias.FindAsync(id);
            if (entity == null) return false;
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
