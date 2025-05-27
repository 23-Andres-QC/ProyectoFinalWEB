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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetPreguntasFrecuentesChatBot();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetPreguntasFrecuentesChatBotById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PreguntasFrecuentesChatBotCreateDTO dto)
        {
            var id = await _service.CreatePreguntasFrecuentesChatBot(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            var updated = await _service.UpdatePreguntasFrecuentesChatBot(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePreguntasFrecuentesChatBot(id);
            return NoContent();
        }
    }
}
