using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly vdiContext _context;

        public CategoriaRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las categorías
        public async Task<List<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.Where(c => c.Estado == 1).ToListAsync();
        }

        // Obtener categoría por ID
        public async Task<Categorias?> GetByIdAsync(int id)
        {
            return await _context.Categorias.Where(c => c.IdCategoria == id && c.Estado == 1).FirstOrDefaultAsync();
        }

        // Crear nueva categoría
        public async Task<int> CreateAsync(Categorias categoria)
        {
            categoria.Estado = 1;
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria.IdCategoria;
        }

        // Actualizar una categoría existente
        public async Task UpdateAsync(Categorias categoria)
        {
            var existing = await _context.Categorias.FindAsync(categoria.IdCategoria);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID {categoria.IdCategoria} para actualizar.");
            }

            existing.Descripcion = categoria.Descripcion;
            // Estado solo se cambia explícitamente
            if (categoria.Estado.HasValue)
                existing.Estado = categoria.Estado;

            _context.Categorias.Update(existing);
            await _context.SaveChangesAsync();
        }

        // Eliminar una categoría por ID
        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID {id} para eliminar.");
            }

            categoria.Estado = 0;
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
