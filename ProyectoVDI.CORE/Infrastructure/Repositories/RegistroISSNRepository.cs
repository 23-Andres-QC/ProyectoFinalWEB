using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RegistroISSNRepository : IRegistroISSNRepository
    {
        private readonly vdiContext _context;

        public RegistroISSNRepository(vdiContext context)
        {
            _context = context;
        }

        // Crear nuevo registro ISSN
        public async Task<int> CreateAsync(RegistroIssn registroISSN)
        {
            await _context.RegistroIssn.AddAsync(registroISSN);
            await _context.SaveChangesAsync();
            return registroISSN.IdRegistroIssn;
        }

        // Obtener todos los registros ISSN
        public async Task<List<RegistroIssn>> GetAllAsync()
        {
            return await _context.RegistroIssn.ToListAsync();
        }

        // Obtener registro ISSN por ID
        public async Task<RegistroIssn?> GetByIdAsync(int id)
        {
            return await _context.RegistroIssn.FindAsync(id);
        }

        // Actualizar un registro ISSN existente
        public async Task UpdateAsync(RegistroIssn registroISSN)
        {
            var existing = await _context.RegistroIssn.FindAsync(registroISSN.IdRegistroIssn);
            if (existing == null)
            {
                throw new InvalidOperationException($"No se encontró el registro ISSN con ID {registroISSN.IdRegistroIssn} para actualizar.");
            }

            _context.Entry(existing).CurrentValues.SetValues(registroISSN);
            await _context.SaveChangesAsync();
        }

        // Eliminar registro ISSN por ID
        public async Task DeleteAsync(int id)
        {
            var registro = await _context.RegistroIssn.FindAsync(id);
            if (registro == null)
            {
                throw new InvalidOperationException($"No se encontró el registro ISSN con ID {id} para eliminar.");
            }

            _context.RegistroIssn.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }
}
