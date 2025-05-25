using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaDTOController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaDTOController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/CategoriaDTO
        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _categoriaService.GetCategorias();
            return Ok(categorias);
        }

        // GET: api/CategoriaDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaById(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        // POST: api/CategoriaDTO
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaCreateDTO categoriaCreateDTO)
        {
            if (categoriaCreateDTO == null)
                return BadRequest("El objeto CategoriaCreateDTO es nulo.");
            if (string.IsNullOrWhiteSpace(categoriaCreateDTO.Descripcion))
                return BadRequest("El campo 'Descripcion' es obligatorio.");
            var newId = await _categoriaService.CreateCategoria(categoriaCreateDTO);
            return Ok(newId);
        }

        // PUT: api/CategoriaDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaUpdateDTO categoriaUpdateDTO)
        {
            if (categoriaUpdateDTO == null || categoriaUpdateDTO.IdCategoria != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (string.IsNullOrWhiteSpace(categoriaUpdateDTO.Descripcion))
                return BadRequest("El campo 'Descripcion' es obligatorio.");
            var result = await _categoriaService.UpdateCategoria(categoriaUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Categoria actualizada correctamente.");
        }

        // DELETE: api/CategoriaDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            await _categoriaService.DeleteCategoria(id);
            return NoContent();
        }
    }
}
