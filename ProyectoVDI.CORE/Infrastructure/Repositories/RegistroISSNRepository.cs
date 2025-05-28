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
        public async Task<bool> CreateAsync(RegistroIssn registroISSN)
        {
            try
            {
                _context.RegistroIssn.Add(registroISSN);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error en CreateAsync: {ex.Message}");
                return false;
            }
        }

        // Obtener todos los registros ISSN
        public async Task<List<RegistroIssn>> GetAllAsync()
        {
            try
            {
                return await _context.RegistroIssn.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllAsync: {ex.Message}");
                return new List<RegistroIssn>();
            }
        }

        // Obtener registro ISSN por ID
        public async Task<RegistroIssn?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.RegistroIssn.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetByIdAsync: {ex.Message}");
                return null;
            }
        }


        // Obtener registro ISSN por fecha
        public async Task<List<RegistroIssn>> GetByFechaAsync(DateOnly fecha)
        {
            try
            {
                var registros = await _context.RegistroIssn
                    .Where(r => r.FechaRegistro != null && r.FechaRegistro == fecha)
                    .ToListAsync();

                return registros;
            }
            catch (Exception ex)
            {
                // Manejo del error o log
                return new List<RegistroIssn>();
            }
        }



        // Actualizar un registro ISSN existente
        public async Task<bool> UpdateAsync(RegistroIssn registroISSN)
        {
            try
            {
                _context.RegistroIssn.Update(registroISSN);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateAsync: {ex.Message}");
                return false;
            }
        }



        // Eliminar un registro ISSN por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.RegistroIssn.FindAsync(id);
                if (entity == null) return false;

                _context.RegistroIssn.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteAsync: {ex.Message}");
                return false;
            }
        }
    }
}
