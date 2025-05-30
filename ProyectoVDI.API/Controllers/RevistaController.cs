using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.Services;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevistaController : ControllerBase
    {
        private readonly IRevistaService _service;

        public RevistaController(IRevistaService service)
        {
            _service = service;
        }
        //api/revista
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetRevistas();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetRevistaById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RevistaCreateDTO dto)
        {
            var id = await _service.CreateRevista(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RevistaUpdateDTO dto)
        {
            var updated = await _service.UpdateRevista(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRevista(id);
            return NoContent();
        }

        // api/revista/fullflat

        [HttpGet("fullflat")]
        public async Task<IActionResult> GetRevistasFullFlat()
        {
            var revistas = await _service.GetRevistasFullFlat();
            return Ok(revistas);
        }
    }
}
