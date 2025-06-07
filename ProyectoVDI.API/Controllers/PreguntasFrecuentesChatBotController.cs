using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PreguntasFrecuentesChatBotController : ControllerBase
    {
        private readonly IPreguntasFrecuentesChatBotService _service;
        public PreguntasFrecuentesChatBotController(IPreguntasFrecuentesChatBotService service)
        {
            _service = service;
        }

        //obtener id y las preguntas frecuentes del chatbot
        // api/preguntasfrecuenteschatbot
        [HttpGet]
        public async Task<IActionResult> GetAllpreguntas() { 
            var preguntas = await _service.GetAllPreguntasAsync();
            if (preguntas == null || !preguntas.Any()) return NotFound("No hay preguntas frecuentes disponibles.");
            return Ok(preguntas);

        }
        //obtener una pregunta frecuente del chatbot por ID
        // api/preguntasfrecuenteschatbot/byId/{id}
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetByIdPregunta(int id)
        {
            var pregunta = await _service.GetByIdAsync(id);
            if (pregunta == null) return NotFound("Pregunta frecuente no encontrada.");
            return Ok(pregunta);
        }


        //obtener todas las preguntas frecuentes del chatbot con detalles
        // api/preguntasfrecuenteschatbot/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var preguntas = await _service.GetAllAsync();
            if (preguntas == null || !preguntas.Any()) return NotFound("No hay preguntas frecuentes disponibles.");
            return Ok(preguntas);
        }

        // crear una pregunta frecuente del chatbot
        // api/preguntasfrecuenteschatbot

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PreguntasFrecuentesChatBotCreateDTO dto)
        {
            if (dto == null) return BadRequest("Los datos de la pregunta frecuente son inválidos.");
            var createdId = await _service.CreateAsync(dto); // Assuming CreateAsync returns an int (IdPregunta)
            if (createdId <= 0) return BadRequest("Error al crear la pregunta frecuente.");
            return CreatedAtAction(nameof(GetByIdPregunta), new { id = createdId }, dto);
        }


        // actualizar todo lo relacionado a las preguntas frecuentes del chatbot
        // api/preguntasfrecuenteschatbot
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            if (dto == null || dto.IdPregunta <= 0) return BadRequest("Los datos de la pregunta frecuente son inválidos.");
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound("Pregunta frecuente no encontrada o error al actualizar.");
            return NoContent();
        }
        // actualizar el estado de una pregunta frecuente del chatbot 
        // api/preguntasfrecuenteschatbot/updateEstado
        public async Task<IActionResult> UpdateEstado([FromBody] ActualizarEstadoPreguntaFrecuenteDTO dto)
        {
            if (dto == null || dto.IdPregunta <= 0) return BadRequest("Los datos de la pregunta frecuente son inválidos.");
            var updated = await _service.UpdateEstadoAsync(dto);
            if (!updated) return NotFound("Pregunta frecuente no encontrada o error al actualizar el estado.");
            return NoContent();
        }


        // eliminar una pregunta frecuente del chatbot por ID
        // api/preguntasfrecuenteschatbot/delete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
