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
    
    public class CalificacionChatBotDTOController : ControllerBase
    {
        private readonly ICalificacionChatBotService _service;

        public CalificacionChatBotDTOController(ICalificacionChatBotService service)
        {
            _service = service;
        }

        //crear una nueva calificaci�n de chatbots
        // POST: api/CalificacionChatBot/CreateCalificacionChatBot

        [HttpPost("Create")]
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

        // actualizar una calificaci�n de chatbots
        // PUT: api/CalificacionChatBot/UpdateCalificacionChatBot
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCalificacionChatBotDTO dto)
        {
            var result = await _service.UpdateAsync(dto);
            return Ok(result); // devolverá true si todo fue bien
        }

        // eliminar una calificaci�n de chatbots por ID
        // DELETE: api/CalificacionChatBot/DeleteCalificacionChatBot/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCalificacionChatBot(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que cero.");
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound("Calificaci�n de chatbots no encontrada.");
            return Ok("Calificaci�n de chatbots eliminada correctamente.");
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