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
    public class EvaluacionesRepository : IEvaluacionesRepository
    {
        private readonly vdiContext _context;
        public EvaluacionesRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evaluaciones>> GetAllEvaluacionesAsync()
        {
            return await _context.Evaluaciones.ToListAsync();
        }
        public async Task<Evaluaciones?> GetEvaluacionById(int id)
        {
            return await _context.Evaluaciones.FindAsync(id);
        }

        public async Task AddEvaluacionAsync(Evaluaciones evaluacion)
        {
            await _context.Evaluaciones.AddAsync(evaluacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvaluacionAsync(Evaluaciones evaluacion)
        {
            _context.Evaluaciones.Update(evaluacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvaluacionAsync(int id)
        {
            var evaluacion = await GetEvaluacionById(id);
            if (evaluacion != null)
            {
                _context.Evaluaciones.Remove(evaluacion);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Evaluaciones>> GetEvaluacionesByOrdenAsync(int idRevista)
        {
            return await _context.Evaluaciones.Where(e => e.IdRevista == idRevista).ToListAsync();
        }

    }
}
