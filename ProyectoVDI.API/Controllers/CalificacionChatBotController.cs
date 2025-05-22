using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionChatBotController : ControllerBase
    {
        private readonly ICalificacionChatBotRepository _repository;

        public CalificacionChatBotController(ICalificacionChatBotRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CalificacionChatBot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificacionChatBot>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/CalificacionChatBot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalificacionChatBot>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/CalificacionChatBot
        [HttpPost]
        public async Task<ActionResult<CalificacionChatBot>> Create(CalificacionChatBot entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdFeedback }, entity);
        }

        // PUT: api/CalificacionChatBot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CalificacionChatBot entity)
        {
            if (id != entity.IdFeedback)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/CalificacionChatBot/5
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
