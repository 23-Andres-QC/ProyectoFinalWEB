using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistaRepository : IRevistaRepository
    {
        private readonly vdiContext _context;
        public RevistaRepository(vdiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Revista>> GetAllAsync()
        {
            return await _context.Revista.ToListAsync();
        }
        //obtener revista por id

        public async Task<Revista?> GetByIdAsync(int id)
        {
            return await _context.Revista.FindAsync(id);
        }

        // Crear una nueva revista
        public async Task<int> CreateAsync(Revista entity)
        {
            // Estado y fechas pueden ser gestionados aquí si aplica
            entity.Estado = 1; // Activo por defecto
            _context.Revista.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRevista;
        }

        // Actualizar una revista existente

        public async Task<bool> UpdateAsync(Revista entity)
        {
            var existing = await _context.Revista.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar una revista (soft delete)
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Revista.FindAsync(id);
            if (entity == null) return false;
            // Soft delete: cambiar estado
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
