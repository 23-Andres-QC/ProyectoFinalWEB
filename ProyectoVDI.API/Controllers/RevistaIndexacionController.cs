using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevistaIndexacionController : ControllerBase
    {
        private readonly IRevistaIndexacionService _service;

        public RevistaIndexacionController(IRevistaIndexacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetRevistaIndexaciones();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetRevistaIndexacionById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RevistaIndexacionCreateDTO dto)
        {
            var id = await _service.CreateRevistaIndexacion(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RevistaIndexacionUpdateDTO dto)
        {
            var updated = await _service.UpdateRevistaIndexacion(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRevistaIndexacion(id);
            return NoContent();
        }
    }
}
