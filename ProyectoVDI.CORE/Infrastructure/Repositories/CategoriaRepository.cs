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
            return await _context.Categorias.ToListAsync();
        }

        // Obtener categoría por ID (con excepción si no existe)
        public async Task<Categorias> GetByIdAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                throw new InvalidOperationException($"No se encontró una categoría con el ID {id}.");
            }
            return categoria;
        }

        // Crear nueva categoría
        public async Task<int> CreateAsync(Categorias categoria)
        {
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

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
