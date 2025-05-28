using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // Repositorio para la entidad Evaluaciones, implementa IEvaluacionesRepository
    public class EvaluacionesRepository : IEvaluacionesRepository
    {
        // Contexto de base de datos inyectado
        private readonly vdiContext _context;

        // Constructor que recibe el contexto
        public EvaluacionesRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las evaluaciones
        public async Task<List<Evaluaciones>> GetAllAsync()
        {
            return await _context.Evaluaciones.ToListAsync();
        }

        // Obtener evaluación por ID
        public async Task<Evaluaciones?> GetByIdAsync(int id)
        {
            return await _context.Evaluaciones.FindAsync(id);
        }

        // Crear nueva evaluación
        public async Task<int> CreateAsync(Evaluaciones evaluacion)
        {
            await _context.Evaluaciones.AddAsync(evaluacion);
            await _context.SaveChangesAsync();
            return evaluacion.IdEvaluacion;
        }

        // Actualizar evaluación existente
        public async Task UpdateAsync(Evaluaciones evaluacion)
        {
            var existing = await _context.Evaluaciones.FindAsync(evaluacion.IdEvaluacion);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la evaluación con ID {evaluacion.IdEvaluacion} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(evaluacion);
            await _context.SaveChangesAsync();
        }

        // Eliminar evaluación (borrado físico)
        public async Task DeleteAsync(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion == null)
            {
                throw new InvalidOperationException($"No se encontró la evaluación con ID {id} para eliminar.");
            }

            _context.Evaluaciones.Remove(evaluacion);
            await _context.SaveChangesAsync();
        }
    }
}
