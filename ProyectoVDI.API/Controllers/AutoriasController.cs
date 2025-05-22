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
    public class AutoriasController : ControllerBase
    {
        private readonly vdiContext _context;

        public AutoriasController(vdiContext context)
        {
            _context = context;
        }

        // GET: api/Autorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autoria>>> GetAutoria()
        {
            return await _context.Autoria.ToListAsync();
        }

        // GET: api/Autorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autoria>> GetAutoria(int id)
        {
            var autoria = await _context.Autoria.FindAsync(id);

            if (autoria == null)
            {
                return NotFound();
            }

            return autoria;
        }

        // PUT: api/Autorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutoria(int id, Autoria autoria)
        {
            if (id != autoria.IdAutoria)
            {
                return BadRequest();
            }

            _context.Entry(autoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoriaExists(id))
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

        // POST: api/Autorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autoria>> PostAutoria(Autoria autoria)
        {
            _context.Autoria.Add(autoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoria", new { id = autoria.IdAutoria }, autoria);
        }

        // DELETE: api/Autorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoria(int id)
        {
            var autoria = await _context.Autoria.FindAsync(id);
            if (autoria == null)
            {
                return NotFound();
            }

            _context.Autoria.Remove(autoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoriaExists(int id)
        {
            return _context.Autoria.Any(e => e.IdAutoria == id);
        }
    }
}
