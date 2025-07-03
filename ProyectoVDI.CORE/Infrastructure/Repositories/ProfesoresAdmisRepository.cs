using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class ProfesoresAdmisRepository : IProfesoresAdmisRepository
    {
        private readonly vdiContext _context;
        public ProfesoresAdmisRepository(vdiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfesoresAdmis>> GetAllAsync()
        {
            // Incluye la navegación a Categorias para que la descripción esté disponible
            return await _context.ProfesoresAdmis
                .Include(p => p.IdCategoriaNavigation)
                .ToListAsync();
        }

        public async Task<ProfesoresAdmis?> GetByIdAsync(int id)
        {
            // Incluye la navegación a Categorias para que la descripción esté disponible
            return await _context.ProfesoresAdmis
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(p => p.Id_Profesor_Admis == id);
        }

        public async Task<int> CreateAsync(ProfesoresAdmis entity)
        {
            entity.Estado = 1;
            _context.ProfesoresAdmis.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id_Profesor_Admis;
        }

        public async Task<bool> UpdateAsync(ProfesoresAdmis entity)
        {
            var existing = await _context.ProfesoresAdmis.FindAsync(entity.Id_Profesor_Admis);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ProfesoresAdmis.FindAsync(id);
            if (entity == null) return false;
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
