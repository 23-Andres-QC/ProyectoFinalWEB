using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    public class RevistaRepository : IRevistaRepository
    {
        private readonly vdiContext _context;
        public RevistaRepository(vdiContext context)
        {
            _context = context;
        }

        //obtener todas las revistas
        public async Task<IEnumerable<Revista>> GetAllAsync()
        {
            return await _context.Revista.ToListAsync();
        }
        //obtener revista por id

        public async Task<Revista?> GetByIdAsync(int id)
        {
            return await _context.Revista.FindAsync(id);
        }

        // Crear una nueva revista
        public async Task<int> CreateAsync(Revista entity)
        {
            // Estado y fechas pueden ser gestionados aquí si aplica
            entity.Estado = 1; // Activo por defecto
            _context.Revista.Add(entity);
            await _context.SaveChangesAsync();
            return entity.IdRevista;
        }

        //crear una nueva revista completaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public async Task<bool> CreateAsync(
        Revista revista,
        List<IssnsRevista>? listaIssns,
        MetadatosRevistaIssn? metadatos,
        RegistroRevistas registro)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Agregar la revista
                _context.Revista.Add(revista);
                await _context.SaveChangesAsync(); // genera IdRevista

                // 2. Agregar ISSNs
                if (listaIssns != null)
                {
                    foreach (var issn in listaIssns)
                    {
                        issn.IdRevista = revista.IdRevista;
                        _context.IssnsRevista.Add(issn);
                    }
                }

                // 3. Agregar metadatos
                if (metadatos != null)
                {
                    metadatos.IdRevista = revista.IdRevista;

                    int contadorListas = 0;
                    if (!string.IsNullOrEmpty(metadatos.Scopus)) contadorListas++;
                    if (!string.IsNullOrEmpty(metadatos.WoSQ)) contadorListas++;
                    if (!string.IsNullOrEmpty(metadatos.EsciQ)) contadorListas++;
                    if (!string.IsNullOrEmpty(metadatos.Ajg4star)) contadorListas++;
                    if (!string.IsNullOrEmpty(metadatos.Cnrs)) contadorListas++;
                    if (!string.IsNullOrEmpty(metadatos.Abdc)) contadorListas++;

                    metadatos.N = contadorListas;

                    _context.MetadatosRevistaIssn.Add(metadatos);
                }

                // 4. Agregar registro
                _context.RegistroRevistas.Add(registro);
                await _context.SaveChangesAsync(); // genera IdRegistro

                // 5. Crear y agregar detalle
                var detalle = new DetRegistroRevista
                {
                    IdRegistro = registro.IdRegistro,
                    IdRevista = revista.IdRevista
                };
                _context.DetRegistroRevista.Add(detalle);

                // 6. Guardar todo y confirmar
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }





        // Actualizar una revista existente


        public async Task<bool> UpdateAsync(Revista entity)
        {
            var existing = await _context.Revista.FindAsync(entity.IdRevista);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar una revista (soft delete)
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Revista.FindAsync(id);
            if (entity == null) return false;
            // Soft delete: cambiar estado
            entity.Estado = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
