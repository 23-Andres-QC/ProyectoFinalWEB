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
    public class PreguntasFrecuentesChatBotDTOController : ControllerBase
    {
        private readonly IPreguntasFrecuentesChatBotService _service;

        public PreguntasFrecuentesChatBotDTOController(IPreguntasFrecuentesChatBotService service)
        {
            _service = service;
        }

        // GET: api/PreguntasFrecuentesChatBotDTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var preguntas = await _service.GetPreguntasFrecuentesChatBot();
            return Ok(preguntas);
        }

        // GET: api/PreguntasFrecuentesChatBotDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pregunta = await _service.GetPreguntasFrecuentesChatBotById(id);
            if (pregunta == null)
                return NotFound();
            return Ok(pregunta);
        }

        // POST: api/PreguntasFrecuentesChatBotDTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PreguntasFrecuentesChatBotCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto PreguntasFrecuentesChatBotCreateDTO es nulo.");
            if (string.IsNullOrWhiteSpace(dto.Pregunta))
                return BadRequest("El campo 'Pregunta' es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Respuesta))
                return BadRequest("El campo 'Respuesta' es obligatorio.");
            var newId = await _service.CreatePreguntasFrecuentesChatBot(dto);
            return Ok(newId);
        }

        // PUT: api/PreguntasFrecuentesChatBotDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            if (dto == null || dto.IdPregunta != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (string.IsNullOrWhiteSpace(dto.Pregunta))
                return BadRequest("El campo 'Pregunta' es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Respuesta))
                return BadRequest("El campo 'Respuesta' es obligatorio.");
            var result = await _service.UpdatePreguntasFrecuentesChatBot(dto);
            if (!result)
                return NotFound();
            return Ok("Pregunta frecuente actualizada correctamente.");
        }

        // DELETE: api/PreguntasFrecuentesChatBotDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePreguntasFrecuentesChatBot(id);
            return NoContent();
        }
    }
}
