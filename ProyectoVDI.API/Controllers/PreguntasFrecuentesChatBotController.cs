using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasFrecuentesChatBotController : ControllerBase
    {
        private readonly IPreguntasFrecuentesChatBotRepository _repository;

        public PreguntasFrecuentesChatBotController(IPreguntasFrecuentesChatBotRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PreguntasFrecuentesChatBot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntasFrecuentesChatBot>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/PreguntasFrecuentesChatBot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntasFrecuentesChatBot>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/PreguntasFrecuentesChatBot
        [HttpPost]
        public async Task<ActionResult<PreguntasFrecuentesChatBot>> Create(PreguntasFrecuentesChatBot entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdPregunta }, entity);
        }

        // PUT: api/PreguntasFrecuentesChatBot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PreguntasFrecuentesChatBot entity)
        {
            if (id != entity.IdPregunta)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/PreguntasFrecuentesChatBot/5
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
