using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

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

        // obtener todas las preguntas frecuentes para el Administrador
        // api/preguntasfrecuenteschatbot/admin
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            var result = await _service.GetAllPreguntasFrecuentesChatBot();
            return Ok(result);
        }



        // obtener todas las preguntas frecuentes del chat bot
        // api/preguntasfrecuenteschatbot

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetPreguntasFrecuentesChatBot();
            return Ok(result);
        }

        // obtener una pregunta frecuente del chat bot por id
        // api/preguntasfrecuenteschatbot/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetPreguntasFrecuentesChatBotById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // obtener una respuesta frecuente del chat bot por id
        // api/preguntasfrecuenteschatbot/respuesta/{id}
        [HttpGet]
        [Route("respuesta/{id}")]
        public async Task<IActionResult> GetRespuestaById(int id)
        {
            var result = await _service.GetRespuestaPreguntasFrecuentesChatBotById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // crear una pregunta frecuente del chat bot
        // api/preguntasfrecuenteschatbot
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PreguntasFrecuentesChatBotCreateDTO dto)
        {
            var id = await _service.CreatePreguntasFrecuentesChatBot(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        // actualizar una pregunta frecuente del chat bot
        // api/preguntasfrecuenteschatbot


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            var updated = await _service.UpdatePreguntasFrecuentesChatBot(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // actualizar el estado de una pregunta frecuente del chat bot
        // api/preguntasfrecuenteschatbot/estado
        [HttpPut("estado")]
        public async Task<IActionResult> UpdateEstado([FromBody] UpdateEstadoPreguntasFrecuentesChatBotDTO dto)
        {
            var updated = await _service.UpdateEstadoPreguntasFrecuentesChatBot(dto);
            if (!updated) return NotFound();
            return NoContent();
        }




        // eliminar una pregunta frecuente del chat bot por id
        // api/preguntasfrecuenteschatbot/{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePreguntasFrecuentesChatBot(id);
            return NoContent();
        }
    }
}
