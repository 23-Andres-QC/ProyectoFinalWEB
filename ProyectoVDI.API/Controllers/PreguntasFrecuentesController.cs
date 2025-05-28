using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PreguntasFrecuentesController : ControllerBase
    {
        private readonly IPreguntasFrecuentesChatBotService _service;

        public PreguntasFrecuentesController(IPreguntasFrecuentesChatBotService service)
        {
            _service = service;
        }

        // Crear una nueva pregunta frecuente
        // POST: api/PreguntasFrecuentes/Create
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePreguntasFrecuentes([FromBody] createPreguntasFrecuentesChatBotDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto PreguntasFrecuentesCreateDTO es nulo.");
            if (string.IsNullOrEmpty(dto.Pregunta))
                return BadRequest("El campo 'Pregunta' es obligatorio.");
            if (string.IsNullOrEmpty(dto.Respuesta))
                return BadRequest("El campo 'Respuesta' es obligatorio.");
            var newId = await _service.CreateAsync(dto);
            return Ok(newId);
        }

        // Obtener todas las preguntas frecuentes
        // GET: api/PreguntasFrecuentes/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPreguntasFrecuentes()
        {
            var preguntasFrecuentes = await _service.GetAllAsync();
            return Ok(preguntasFrecuentes);
        }

        // Obtener una pregunta frecuente por ID
        // GET: api/PreguntasFrecuentes/GetById/{id}
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPreguntasFrecuentesById(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que cero.");
            var preguntaFrecuente = await _service.GetByIdAsync(id);
            if (preguntaFrecuente == null)
                return NotFound("Pregunta frecuente no encontrada.");
            return Ok(preguntaFrecuente);
        }

        // Actualizar una pregunta frecuente existente
        // PUT: api/PreguntasFrecuentes/Update
        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePreguntasFrecuentes([FromBody] updatePreguntasFrecuentesChatBotDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto PreguntasFrecuentesUpdateDTO es nulo.");
            if (dto.IdPregunta <= 0)
                return BadRequest("El ID de la pregunta debe ser mayor que cero.");
            await _service.UpdateAsync(dto);
            return Ok("Pregunta frecuente actualizada correctamente.");
        }

        // Actualizar el estado de una pregunta frecuente
        // PUT: api/PreguntasFrecuentes/UpdateEstado
        [HttpPut("UpdateEstado")]
        public async Task<IActionResult> UpdateEstadoPreguntasFrecuentes([FromBody] updateEstadoPreguntasFrecuentesChatBotDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto UpdateEstadoPreguntasFrecuentesDTO es nulo.");
            if (dto.IdPregunta <= 0)
                return BadRequest("El ID de la pregunta debe ser mayor que cero.");
            await _service.UpdateEstadoAsync(dto);
            return Ok("Estado de la pregunta frecuente actualizado correctamente.");
        }

        // Eliminar una pregunta frecuente por ID
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePreguntasFrecuentes(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que cero.");
            await _service.DeleteAsync(id);
            return Ok("Pregunta frecuente eliminada correctamente.");

        }
    }
}
