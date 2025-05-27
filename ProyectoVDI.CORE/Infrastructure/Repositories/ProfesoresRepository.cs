using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class ProfesoresRepository : IProfesoresRepository
    {
        private readonly vdiContext _context;

        public ProfesoresRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todos los profesores
        public async Task<List<Profesores>> GetAllAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        // Obtener profesor por ID
        public async Task<Profesores?> GetByIdAsync(int id)
        {
            return await _context.Profesores.FindAsync(id);
        }

        // Crear nuevo profesor
        public async Task<int> CreateAsync(Profesores profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
            return profesor.IdProfesor;
        }

        // Actualizar profesor existente
        public async Task UpdateAsync(Profesores profesor)
        {
            var existing = await _context.Profesores.FindAsync(profesor.IdProfesor);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró el profesor con ID {profesor.IdProfesor} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(profesor);
            await _context.SaveChangesAsync();
        }

        // Eliminar profesor por ID
        public async Task DeleteAsync(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                throw new InvalidOperationException($"No se encontró el profesor con ID {id} para eliminar.");
            }

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
        }
    }
}
