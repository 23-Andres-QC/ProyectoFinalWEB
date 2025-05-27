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

        //crear una nueva calificación de chatbots
        // POST: api/CalificacionChatBot/CreateCalificacionChatBot

        [HttpPost("CreateCalificacionChatBot")]
        public async Task<IActionResult> CreateCalificacionChatBot([FromBody] CreateCalificacionChatBotDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto CalificacionChatBotCreateDTO es nulo.");
            if (dto.IdUsuario == null)
                return BadRequest("El campo 'IdUsuario' es obligatorio.");
            if (dto.Calificacion == null)
                return BadRequest("El campo 'Calificacion' es obligatorio.");
            var newId = await _service.CreateAsync(dto);
            return Ok(newId);
        }
        // GET: api/CalificacionChatBot/GetCalificacionChatBots
        // obtener todas las calificaciones de chatbots
        [HttpGet]
        public async Task<IActionResult> GetCalificacionChatBots()
        {
            var calificaciones = await _service.GetAllAsync();
            return Ok(calificaciones);
        }


    }
}
