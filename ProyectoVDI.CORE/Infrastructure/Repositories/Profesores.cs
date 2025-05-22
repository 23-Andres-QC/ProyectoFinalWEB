using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    internal class ProfesoresRepository : IProfesoresRepository
    {
        private readonly vdiContext _context;

        public ProfesoresRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesores>> GetAllProfesoresAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesores?> GetProfesorById(int id)
        {
            return await _context.Profesores.FindAsync(id);
        }

        public async Task AddProfesorAsync(Profesores profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesorAsync(Profesores profesor)
        {
            _context.Profesores.Update(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesorAsync(int id)
        {
            var profesor = await GetProfesorById(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
