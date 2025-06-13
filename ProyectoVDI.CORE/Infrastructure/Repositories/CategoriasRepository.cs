using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // Repositorio para la gestión de Categorias en la base de datos
    public class CategoriasRepository : ICategoriasRepository
    {
        // Contexto de base de datos inyectado por dependencia
        private readonly vdiContext _context;
        public CategoriasRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtiene todas las categorias
        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        // Obtiene todas las descripciones de categorias distintas
        public async Task<IEnumerable<string>> GetDistinctDescripcionAsync()
        {
            return await _context.Categorias
                .Select(c => c.Descripcion)
                .Where(d => d != null)
                .Distinct()
                .ToListAsync();
        }

        // Obtiene una categoria por su ID
        public async Task<Categorias?> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        // Crea una nueva categoria
        public async Task<int> CreateAsync(Categorias entity)
        {
            entity.Estado = 1;
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdCategoria;
        }

        // Actualiza una categoria existente
        public async Task<bool> UpdateAsync(Categorias entity)
        {
            var existing = await _context.Categorias.FindAsync(entity.IdCategoria);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Elimina (desactiva) una categoria por su ID (ya no se usará)
        // public async Task<bool> DeleteAsync(int id)
        // {
        //     var entity = await _context.Categorias.FindAsync(id);
        //     if (entity == null) return false;
        //     entity.Estado = 0;
        //     await _context.SaveChangesAsync();
        //     return true;
        // }
    }
}
