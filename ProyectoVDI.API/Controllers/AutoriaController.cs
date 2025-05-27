using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoriaController : ControllerBase
    {
        private readonly IAutoriaService _autoriaService;

        public AutoriaController(IAutoriaService autoriaService)
        {
            _autoriaService = autoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _autoriaService.GetAutorias();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _autoriaService.GetAutoriaById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AutoriaCreateDTO dto)
        {
            var id = await _autoriaService.CreateAutoria(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AutoriaUpdateDTO dto)
        {
            var updated = await _autoriaService.UpdateAutoria(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autoriaService.DeleteAutoria(id);
            return NoContent();
        }
    }
}
