using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        // CREATE registro ISSN
        public async Task CreateAsync(RegistroIssn registroISSN)
        {
            await _context.RegistroIssn.AddAsync(registroISSN);
            await _context.SaveChangesAsync();
        }

        // GET all registro ISSN
        public async Task<List<RegistroIssn>> GetAllAsync()
        {
            return await _context.RegistroIssn.ToListAsync();
        }

        // GET registro ISSN by id
        public async Task<RegistroIssn> GetByIdAsync(int id)
        {
            return await _context.RegistroIssn.FindAsync(id);
        }
        // UPDATE registro ISSN
        public async Task UpdateAsync(RegistroIssn registroISSN)
        {
            _context.RegistroIssn.Update(registroISSN);
            await _context.SaveChangesAsync();
        }
        // DELETE registro ISSN
        public async Task DeleteAsync(int id)
        {
            var registroISSN = await _context.RegistroIssn.FindAsync(id);
            if (registroISSN != null)
            {
                _context.RegistroIssn.Remove(registroISSN);
                await _context.SaveChangesAsync();
            }
        }


    }
}
