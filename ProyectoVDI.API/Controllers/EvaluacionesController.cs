using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Controlador para la gestión de evaluaciones
    public class EvaluacionesController : ControllerBase
    {
        // Servicio de evaluaciones inyectado
        private readonly IEvaluacionesService _service;

        // Constructor que recibe el servicio
        public EvaluacionesController(IEvaluacionesService service)
        {
            _service = service;
        }

        // Obtiene todas las evaluaciones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetEvaluaciones();
            return Ok(result);
        }

        // Obtiene una evaluación por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetEvaluacionesById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Crea una nueva evaluación
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluacionesCreateDTO dto)
        {
            // Validación de modelo
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _service.CreateEvaluaciones(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        // Actualiza una evaluación existente
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EvaluacionesUpdateDTO dto)
        {
            // Validación de modelo
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _service.UpdateEvaluaciones(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // Elimina una evaluación por su ID (si decides mantenerlo)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEvaluaciones(id);
            return NoContent();
        }
    }
}
