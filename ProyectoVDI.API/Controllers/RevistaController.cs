using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevistaListDTO>>> GetAll()
        {
            var revistas = await _service.GetRevistas();
            return Ok(revistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RevistaDTO>> GetById(int id)
        {
            var revista = await _service.GetRevistaById(id);
            if (revista == null) return NotFound();
            return Ok(revista);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RevistaCreateDTO dto)
        {
            var id = await _service.CreateRevista(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RevistaUpdateDTO dto)
        {
            if (id != dto.IdRevista) return BadRequest();
            var updated = await _service.UpdateRevista(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRevista(id);
            return Ok(id);
        }
    }
}