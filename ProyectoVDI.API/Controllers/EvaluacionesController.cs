using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionesService _service;

        public EvaluacionesController(IEvaluacionesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetEvaluaciones();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetEvaluacionesById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluacionesCreateDTO dto)
        {
            var id = await _service.CreateEvaluaciones(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EvaluacionesUpdateDTO dto)
        {
            var updated = await _service.UpdateEvaluaciones(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEvaluaciones(id);
            return NoContent();
        }
    }
}
