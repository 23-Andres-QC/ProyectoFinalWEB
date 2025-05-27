using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresenciaEnListasController : ControllerBase
    {
        private readonly IPresenciaEnListasService _service;

        public PresenciaEnListasController(IPresenciaEnListasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetPresenciaEnListas();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetPresenciaEnListasById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PresenciaEnListasCreateDTO dto)
        {
            var id = await _service.CreatePresenciaEnListas(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PresenciaEnListasUpdateDTO dto)
        {
            var updated = await _service.UpdatePresenciaEnListas(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePresenciaEnListas(id);
            return NoContent();
        }
    }
}
