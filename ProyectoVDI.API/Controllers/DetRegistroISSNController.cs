using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetRegistroIssnController : ControllerBase
    {
        private readonly IDetRegistroIssnService _service;

        public DetRegistroIssnController(IDetRegistroIssnService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetDetRegistroIssn();
            return Ok(result);
        }

        [HttpGet("{idRegistroIssn}/{idRevista}")]
        public async Task<IActionResult> GetById(int idRegistroIssn, int idRevista)
        {
            var result = await _service.GetDetRegistroIssnById(idRegistroIssn, idRevista);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetRegistroIssnCreateDTO dto)
        {
            var id = await _service.CreateDetRegistroIssn(dto);
            return CreatedAtAction(nameof(GetById), new { idRegistroIssn = dto.IdRegistroIssn, idRevista = dto.IdRevista }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DetRegistroIssnUpdateDTO dto)
        {
            var updated = await _service.UpdateDetRegistroIssn(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{idRegistroIssn}/{idRevista}")]
        public async Task<IActionResult> Delete(int idRegistroIssn, int idRevista)
        {
            await _service.DeleteDetRegistroIssn(idRegistroIssn, idRevista);
            return NoContent();
        }
    }
}
