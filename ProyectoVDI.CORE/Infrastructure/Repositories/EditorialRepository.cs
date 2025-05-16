using System;
using ProyectoVDI.Core.Entities;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class EditorialRepository
    {
        private readonly vdiContext _context;

        public EditorialRepository(vdiContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Editorial> GetAll()
        {
            return _context.Editoriales.ToList();
        }

        public async Task<IEnumerable<Editorial>> GetAllAsync()
        {
            return await _context.Editoriales.ToListAsync();
        }

        //Get by id

        public Editorial GetById(int id)
        {
            return _context.Editoriales.FirstOrDefault(e => e.IdEditorial == id);
        }

        public async Task<Editorial> GetByIdAsync(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }

        //Agregar 

        public int Create(Editorial editorial)
        {
            _context.Editoriales.Add(editorial);
            _context.SaveChanges();
            return editorial.IdEditorial;
        }

        public async Task<int> CreateAsync(Editorial editorial)
        {
            await _context.Editoriales.AddAsync(editorial);
            await _context.SaveChangesAsync();
            return editorial.IdEditorial;
        }

        //Actualizar

        public bool Update(Editorial editorial)
        {
            var existing = _context.Editoriales.Find(editorial.IdEditorial);
            if (existing == null)
                return false;

            existing.MDPI = editorial.MDPI;
            existing.INSIGHTS = editorial.INSIGHTS;
            existing.BEALLSLIST = editorial.BEALLSLIST;
            existing.IdRevista = editorial.IdRevista;

            _context.Editoriales.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Editorial editorial)
        {
            var existing = await _context.Editoriales.FindAsync(editorial.IdEditorial);
            if (existing == null)
                return false;

            existing.MDPI = editorial.MDPI;
            existing.INSIGHTS = editorial.INSIGHTS;
            existing.BEALLSLIST = editorial.BEALLSLIST;
            existing.IdRevista = editorial.IdRevista;

            _context.Editoriales.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar

        public bool Delete(int id)
        {
            var editorial = _context.Editoriales.Find(id);
            if (editorial != null)
            {
                _context.Editoriales.Remove(editorial);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial != null)
            {
                _context.Editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
