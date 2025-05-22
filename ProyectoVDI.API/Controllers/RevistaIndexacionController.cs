using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistasIndexacionController : ControllerBase
    {
        private readonly IRevistasIndexacionRepository _repository;

        public RevistasIndexacionController(IRevistasIndexacionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/RevistasIndexacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevistaIndexacion>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/RevistasIndexacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RevistaIndexacion>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/RevistasIndexacion
        [HttpPost]
        public async Task<ActionResult<RevistaIndexacion>> Create(RevistaIndexacion entity)
        {
            var newId = await _repository.CreateAsync(entity);
            entity.IdIndexacion = newId;
            return CreatedAtAction(nameof(GetById), new { id = newId }, entity);
        }

        // PUT: api/RevistasIndexacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RevistaIndexacion entity)
        {
            if (id != entity.IdIndexacion)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/RevistasIndexacion/5
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
