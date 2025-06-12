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
            var resultado = result.Select(x => new CategoriasListNoIdDTO
            {
                
                Descripcion = x.Descripcion,
                Estado = x.Estado
            });
            return Ok(resultado);
        }

        //obtener todas las categorias y detalles
        //api/categorias/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            var result = await _service.GetAllAsync();
            // Mapea a DTO de detalle (incluye IdCategoria)
            var detalles = result.Select(x => new CategoriasDetailDTO
            {
                IdCategoria = x.IdCategoria,
                Descripcion = x.Descripcion,
                Estado = x.Estado
            });
            return Ok(detalles);
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
        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] CategoriasUpdateDTO dto)
        {
            
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/categorias/{id}
        // Ya no elimina la categoria, solo retorna 405 Method Not Allowed
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(405, "La eliminación de categorías no está permitida. Solo se permite actualizar el estado.");
        }
    }
}
