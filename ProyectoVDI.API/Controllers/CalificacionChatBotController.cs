using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionChatBotController : ControllerBase
    {
        private readonly ICalificacionChatBotRepository _calificacionChatBotRepository;

        // Constructor con inyección de dependencias
        public CalificacionChatBotController(ICalificacionChatBotRepository calificacionChatBotRepository)
        {
            _calificacionChatBotRepository = calificacionChatBotRepository;
        }

        // GET: api/CalificacionChatBot
        // Obtiene todas las calificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificacionChatBot>>> GetAll()
        {
            var calificaciones = await _calificacionChatBotRepository.GetAllAsync();
            return Ok(calificaciones);
        }

        // GET: api/CalificacionChatBot/5
        // Obtiene una calificación específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CalificacionChatBot>> GetById(int id)
        {
            var calificacion = await _calificacionChatBotRepository.GetByIdAsync(id);

            if (calificacion == null)
                return NotFound();

            return Ok(calificacion);
        }

        // POST: api/CalificacionChatBot
        // Crea una nueva calificación
        [HttpPost]
        public async Task<ActionResult<CalificacionChatBot>> Create(CalificacionChatBot calificacionChatBot)
        {
            await _calificacionChatBotRepository.CreateAsync(calificacionChatBot);
            return CreatedAtAction(nameof(GetById), new { id = calificacionChatBot.IdFeedback }, calificacionChatBot);
        }

        // PUT: api/CalificacionChatBot/5
        // Actualiza una calificación existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CalificacionChatBot calificacionChatBot)
        {
            if (id != calificacionChatBot.IdFeedback)
                return BadRequest("El ID no coincide con el registro a actualizar.");

            await _calificacionChatBotRepository.UpdateAsync(calificacionChatBot);
            return NoContent(); // Éxito sin contenido
        }

        // DELETE: api/CalificacionChatBot/5
        // Elimina una calificación por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _calificacionChatBotRepository.DeleteAsync(id);
            return NoContent(); // Eliminado correctamente
        }
    }
}
