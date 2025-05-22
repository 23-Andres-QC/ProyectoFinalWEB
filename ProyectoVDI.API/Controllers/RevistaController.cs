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
    public class RevistaController : ControllerBase
    {
        private readonly vdiContext _context;

        public RevistaController(vdiContext context)
        {
            _context = context;
        }

        // GET: api/Revista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revista>>> GetRevista()
        {
            return await _context.Revista.ToListAsync();
        }

        // GET: api/Revista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revista>> GetRevista(int id)
        {
            var revista = await _context.Revista.FindAsync(id);

            if (revista == null)
            {
                return NotFound();
            }

            return revista;
        }

        // PUT: api/Revista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevista(int id, Revista revista)
        {
            if (id != revista.IdRevista)
            {
                return BadRequest();
            }

            _context.Entry(revista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevistaExists(id))
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

        // POST: api/Revista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Revista>> PostRevista(Revista revista)
        {
            _context.Revista.Add(revista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevista", new { id = revista.IdRevista }, revista);
        }

        // DELETE: api/Revista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevista(int id)
        {
            var revista = await _context.Revista.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }

            _context.Revista.Remove(revista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RevistaExists(int id)
        {
            return _context.Revista.Any(e => e.IdRevista == id);
        }
    }
}
