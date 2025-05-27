using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoriaService.GetCategorias();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoriaService.GetCategoriaById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaCreateDTO dto)
        {
            var id = await _categoriaService.CreateCategoria(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoriaUpdateDTO dto)
        {
            var updated = await _categoriaService.UpdateCategoria(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaService.DeleteCategoria(id);
            return NoContent();
        }
    }
}
