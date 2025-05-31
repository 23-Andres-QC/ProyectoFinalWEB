using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _service;
        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        //as
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriasCreateDTO dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriasUpdateDTO dto)
        {
            if (id != dto.IdCategoria) return BadRequest();
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
