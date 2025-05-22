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
    internal class RevistaRepository : IRevistaRepository
    {
        private readonly vdiContext _context;

        public RevistaRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Revista>> GetAllRevistasAsync()
        {
            return await _context.Revista.ToListAsync();
        }

        public async Task<Revista?> GetRevistaById(int id)
        {
            return await _context.Revista.FindAsync(id);
        }

        public async Task AddRevistaAsync(Revista revista)
        {
            await _context.Revista.AddAsync(revista);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRevistaAsync(Revista revista)
        {
            _context.Revista.Update(revista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRevistaAsync(int id)
        {
            var revista = await GetRevistaById(id);
            if (revista != null)
            {
                _context.Revista.Remove(revista);
                await _context.SaveChangesAsync();
            }
        }
    }
}
