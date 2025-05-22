using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class PresenciaEnListasRepository : IPresenciaEnListasRepository
    {
        private readonly vdiContext _context;

        public PresenciaEnListasRepository(vdiContext context)
        {
            _context = context;
        }

        // Obtener todas las presencias en listas
        public async Task<List<PresenciaEnListas>> GetAllAsync()
        {
            return await _context.PresenciaEnListas.ToListAsync();
        }

        // Obtener presencia por ID
        public async Task<PresenciaEnListas> GetByIdAsync(int id)
        {
            var presencia = await _context.PresenciaEnListas.FindAsync(id);
            if (presencia == null)
            {
                throw new InvalidOperationException($"No se encontró la presencia en listas con ID {id}.");
            }
            return presencia;
        }

        // Crear nueva presencia en listas
        public async Task<int> CreateAsync(PresenciaEnListas presencia)
        {
            await _context.PresenciaEnListas.AddAsync(presencia);
            await _context.SaveChangesAsync();
            return presencia.IdLista;
        }

        // Actualizar presencia en listas
        public async Task UpdateAsync(PresenciaEnListas presencia)
        {
            var existing = await _context.PresenciaEnListas.FindAsync(presencia.IdLista);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró la presencia en listas con ID {presencia.IdLista} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(presencia);
            await _context.SaveChangesAsync();
        }

        // Eliminar presencia en listas
        public async Task DeleteAsync(int id)
        {
            var presencia = await _context.PresenciaEnListas.FindAsync(id);
            if (presencia == null)
            {
                throw new InvalidOperationException($"No se encontró la presencia en listas con ID {id} para eliminar.");
            }

            _context.PresenciaEnListas.Remove(presencia);
            await _context.SaveChangesAsync();
        }
    }
}
