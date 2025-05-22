using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistaController : ControllerBase
    {
        private readonly IRevistaRepository _repository;

        public RevistaController(IRevistaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Revista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revista>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Revista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revista>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/Revista
        [HttpPost]
        public async Task<ActionResult<Revista>> Create(Revista entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdRevista }, entity); // Asegúrate que esta propiedad exista
        }

        // PUT: api/Revista/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Revista entity)
        {
            if (id != entity.IdRevista)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/Revista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
