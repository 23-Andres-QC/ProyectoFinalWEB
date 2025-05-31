using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificacionChatBotController : ControllerBase
    {
        private readonly ICalificacionChatBotService _service;
        public CalificacionChatBotController(ICalificacionChatBotService service)
        {
            _service = service;
        }

        // obtener solo calificaciones de chatbots segun los usuario
        // api/calificacionchatbot
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        // obtener calificacion por id DEL USUARIO del chat bot
        //  api/calificacionchatbot/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            var result = await _service.GetByIdListAsync(usuarioId);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }

        // obtener calificacion del chat bot con todo detalle
        // api/calificacionchatbot/detail
        [HttpGet("detail")]
        public async Task<IActionResult> GetAllDetail()
        {
            var result = await _service.GetAllDetailAsync();
            return Ok(result);
        }

        //CREAR calificacion del chat bot
        // api/calificacionchatbot
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CalificacionChatBotCreateDTO dto)
        {
            if (dto == null) return BadRequest("Invalid data.");
            var createdId = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByUsuarioId), new { usuarioId = createdId }, dto);
        }

        // actualizar calificacion del chat bot
        // api/calificacionchatbot
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CalificacionChatBotUpdateDTO dto)
        {
            if (dto == null) return BadRequest("Invalid data.");
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }


        // eliminar calificacion del chat bot por id
        // api/calificacionchatbot/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
