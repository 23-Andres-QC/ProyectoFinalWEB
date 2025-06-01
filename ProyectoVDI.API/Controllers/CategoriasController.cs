using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Linq; // Para usar .Select

namespace ProyectoVDI.API.Controllers
{
    // Controlador para exponer los endpoints CRUD de Categorias
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        // Servicio de Categorias inyectado por dependencia
        private readonly ICategoriasService _service;
        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        // GET: api/categorias
        // Obtiene todas las categorias sin mostrar el IdCategoria
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            // Mapea a DTO sin IdCategoria
            var resultNoId = result.Select(x => new CategoriasListNoIdDTO
            {
                Descripcion = x.Descripcion,
                Estado = x.Estado
            });
            return Ok(resultNoId);
        }

        // GET: api/categorias/{id}
        // Obtiene una categoria por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        // POST: api/categorias
        // Crea una nueva categoria
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriasCreateDTO dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        // PUT: api/categorias/{id}
        // Actualiza una categoria existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriasUpdateDTO dto)
        {
            if (id != dto.IdCategoria) return BadRequest();
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/categorias/{id}
        // Elimina (desactiva) una categoria
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
