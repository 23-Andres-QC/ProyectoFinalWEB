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
    public class RevistaRepository : IRevistaRepository
    {
        private readonly vdiContext _context;

        public RevistaRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las revistas (simple list)
        public async Task<List<Revista>> GetAllAlgunasAsync()
        {
            var revistas = await _context.Revista
                .Select(r => new Revista {
                    IdRevista = r.IdRevista,
                    Nombre = r.Nombre,
                    Issn = r.Issn,
                    Estado = r.Estado
                })
                .Where(r => r.Estado == 1)
                .ToListAsync();
            return revistas;
        }

        //Obtener todos los campos (full list)
        public async Task<List<Revista>> GetAllAsync()
        {
            var revistas = await _context.Revista
                .Where(r => r.Estado == 1)
                .ToListAsync();
            return revistas;
        }

        // Obtener revista por ID
        public async Task<Revista?> GetByIdAsync(int id)
        {
            // Quitar el filtro Estado == 1 para permitir encontrar la revista aunque Estado sea 0
            return await _context.Revista
                .Where(r => r.IdRevista == id)
                .FirstOrDefaultAsync();
        }

        // Crear nueva revista
        public async Task<int> CreateAsync(Revista revista)
        {
            revista.Estado = 1;
            await _context.Revista.AddAsync(revista);
            await _context.SaveChangesAsync();
            return revista.IdRevista;
        }

        // Actualizar revista existente
        public async Task<int> UpdateAsync(Revista revista)
        {
            var existing = await _context.Revista.FindAsync(revista.IdRevista);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la revista con ID {revista.IdRevista} para actualizar.");
            }
            _context.Entry(existing).CurrentValues.SetValues(revista);
            await _context.SaveChangesAsync();
            return existing.IdRevista;
        }

        // Eliminar revista por ID
        public async Task<string> DeleteAsync(int id)
        {
            var revista = await _context.Revista.FindAsync(id);
            if (revista == null)
            {
                throw new InvalidOperationException($"No se encontró la revista con ID {id} para eliminar.");
            }
            revista.Estado = 0;
            await _context.SaveChangesAsync();
            return "Revista inhabilitada";
        }
    }
}
