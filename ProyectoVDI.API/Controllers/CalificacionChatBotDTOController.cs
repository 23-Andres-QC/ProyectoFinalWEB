using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalificacionChatBotDTOController : ControllerBase
    {
        private readonly ICalificacionChatBotService _service;

        public CalificacionChatBotDTOController(ICalificacionChatBotService service)
        {
            _service = service;
        }

        // GET: api/CalificacionChatBotDTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calificaciones = await _service.GetCalificacionChatBots();
            return Ok(calificaciones);
        }

        // GET: api/CalificacionChatBotDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cal = await _service.GetCalificacionChatBotById(id);
            if (cal == null)
                return NotFound();
            return Ok(cal);
        }

        // POST: api/CalificacionChatBotDTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CalificacionChatBotCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto CalificacionChatBotCreateDTO es nulo.");
            if (dto.IdUsuario == null)
                return BadRequest("El campo 'IdUsuario' es obligatorio.");
            if (dto.Calificacion == null)
                return BadRequest("El campo 'Calificacion' es obligatorio.");
            var newId = await _service.CreateCalificacionChatBot(dto);
            return Ok(newId);
        }

        // PUT: api/CalificacionChatBotDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CalificacionChatBotUpdateDTO dto)
        {
            if (dto == null || dto.IdFeedback != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (dto.IdUsuario == null)
                return BadRequest("El campo 'IdUsuario' es obligatorio.");
            if (dto.Calificacion == null)
                return BadRequest("El campo 'Calificacion' es obligatorio.");
            var result = await _service.UpdateCalificacionChatBot(dto);
            if (!result)
                return NotFound();
            return Ok("Calificación actualizada correctamente.");
        }

        // DELETE: api/CalificacionChatBotDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCalificacionChatBot(id);
            return NoContent();
        }
    }
}
