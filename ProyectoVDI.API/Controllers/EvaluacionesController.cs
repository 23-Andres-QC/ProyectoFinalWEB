using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionesRepository _repository;

        public EvaluacionesController(IEvaluacionesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Evaluaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluaciones>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Evaluaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluaciones>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/Evaluaciones
        [HttpPost]
        public async Task<ActionResult<Evaluaciones>> Create(Evaluaciones entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdEvaluacion }, entity); // Ajusta si el nombre del ID es diferente
        }

        // PUT: api/Evaluaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evaluaciones entity)
        {
            if (id != entity.IdEvaluacion)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/Evaluaciones/5
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
