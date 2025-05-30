using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

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
        //api/CalificacionChatBot
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetCalificacionChatBots();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetCalificacionChatBotById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        //api/CalificacionChatBot

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CalificacionChatBotCreateDTO dto)
        {
            var id = await _service.CreateCalificacionChatBot(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }
        // api/CalificacionChatBot

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CalificacionChatBotUpdateDTO dto)
        {
            var updated = await _service.UpdateCalificacionChatBot(dto);
            if (!updated) return NotFound();
            return NoContent();
        }
        // api/CalificacionChatBot/2

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCalificacionChatBot(id);
            return NoContent();
        }
    }
}
