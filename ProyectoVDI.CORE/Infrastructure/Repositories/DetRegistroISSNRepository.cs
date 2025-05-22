using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class DetRegistroISSNRepository : IDetRegistroISSNRepository
    {
        private readonly vdiContext _context;

        public DetRegistroISSNRepository(vdiContext context)
        {
            _context = context;
        }

        // Crear nuevo detalle de registro ISSN
        public async Task CreateAsync(DetRegistroIssn detalle)
        {
            await _context.DetRegistroIssn.AddAsync(detalle);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los detalles
        public async Task<List<DetRegistroIssn>> GetAllAsync()
        {
            return await _context.DetRegistroIssn.ToListAsync();
        }

        // Obtener detalles por Id_RegistroISSN
        public async Task<List<DetRegistroIssn>> GetByRegistroIdAsync(int idRegistroIssn)
        {
            return await _context.DetRegistroIssn
                .Where(d => d.IdRegistroIssn == idRegistroIssn)
                .ToListAsync();
        }

        // Actualizar un detalle (requiere clave compuesta)
        public async Task UpdateAsync(DetRegistroIssn detalle)
        {
            var existing = await _context.DetRegistroIssn
                .FirstOrDefaultAsync(d => d.IdRegistroIssn == detalle.IdRegistroIssn && d.IdRevista == detalle.IdRevista);

            if (existing == null)
            {
                throw new InvalidOperationException("No se encontró el detalle del registro ISSN para actualizar.");
            }

            existing.IdTipo = detalle.IdTipo;
            await _context.SaveChangesAsync();
        }

        // Eliminar detalle (por clave compuesta)
        public async Task DeleteAsync(int idRegistroIssn, int idRevista)
        {
            var detalle = await _context.DetRegistroIssn
                .FirstOrDefaultAsync(d => d.IdRegistroIssn == idRegistroIssn && d.IdRevista == idRevista);

            if (detalle == null)
            {
                throw new InvalidOperationException("No se encontró el detalle del registro ISSN para eliminar.");
            }

            _context.DetRegistroIssn.Remove(detalle);
            await _context.SaveChangesAsync();
        }
    }
}
