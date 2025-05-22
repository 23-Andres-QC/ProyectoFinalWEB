using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Infrastructure.Data;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenciaEnListaController : ControllerBase
    {
        private readonly vdiContext _context;

        public PresenciaEnListaController(vdiContext context)
        {
            _context = context;
        }

        // GET: api/PresenciaEnLista
        //QUIERO VER SI HAY PRESENCIA DE USUARIOS
        // EN UNA LISTA DE REVISTAS
        //HOLAAAAA MUNDOOOO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresenciaEnListas>>> GetPresenciaEnListas()
        {
            return await _context.PresenciaEnListas.ToListAsync();
        }

        // GET: api/PresenciaEnLista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresenciaEnListas>> GetPresenciaEnListas(int id)
        {
            var presenciaEnListas = await _context.PresenciaEnListas.FindAsync(id);

            if (presenciaEnListas == null)
            {
                return NotFound();
            }

            return presenciaEnListas;
        }

        // PUT: api/PresenciaEnLista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresenciaEnListas(int id, PresenciaEnListas presenciaEnListas)
        {
            if (id != presenciaEnListas.IdLista)
            {
                return BadRequest();
            }

            _context.Entry(presenciaEnListas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresenciaEnListasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PresenciaEnLista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PresenciaEnListas>> PostPresenciaEnListas(PresenciaEnListas presenciaEnListas)
        {
            _context.PresenciaEnListas.Add(presenciaEnListas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresenciaEnListas", new { id = presenciaEnListas.IdLista }, presenciaEnListas);
        }

        // DELETE: api/PresenciaEnLista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresenciaEnListas(int id)
        {
            var presenciaEnListas = await _context.PresenciaEnListas.FindAsync(id);
            if (presenciaEnListas == null)
            {
                return NotFound();
            }

            _context.PresenciaEnListas.Remove(presenciaEnListas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PresenciaEnListasExists(int id)
        {
            return _context.PresenciaEnListas.Any(e => e.IdLista == id);
        }
    }
}
