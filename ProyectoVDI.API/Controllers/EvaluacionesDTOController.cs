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
    public class EvaluacionesDTOController : ControllerBase
    {
        private readonly IEvaluacionesService _evaluacionesService;

        public EvaluacionesDTOController(IEvaluacionesService evaluacionesService)
        {
            _evaluacionesService = evaluacionesService;
        }

        // GET: api/EvaluacionesDTO
        [HttpGet]
        public async Task<IActionResult> GetAllEvaluaciones()
        {
            var evaluaciones = await _evaluacionesService.GetEvaluaciones();
            return Ok(evaluaciones);
        }

        // GET: api/EvaluacionesDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvaluacionesById(int id)
        {
            var evaluacion = await _evaluacionesService.GetEvaluacionesById(id);
            if (evaluacion == null)
                return NotFound();
            return Ok(evaluacion);
        }

        // POST: api/EvaluacionesDTO
        [HttpPost]
        public async Task<IActionResult> CreateEvaluaciones([FromBody] EvaluacionesCreateDTO evaluacionesCreateDTO)
        {
            if (evaluacionesCreateDTO == null)
                return BadRequest("El objeto EvaluacionesCreateDTO es nulo.");
            if (evaluacionesCreateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var newId = await _evaluacionesService.CreateEvaluaciones(evaluacionesCreateDTO);
            return Ok(newId);
        }

        // PUT: api/EvaluacionesDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvaluaciones(int id, [FromBody] EvaluacionesUpdateDTO evaluacionesUpdateDTO)
        {
            if (evaluacionesUpdateDTO == null || evaluacionesUpdateDTO.IdEvaluacion != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (evaluacionesUpdateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var result = await _evaluacionesService.UpdateEvaluaciones(evaluacionesUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Evaluación actualizada correctamente.");
        }

        // DELETE: api/EvaluacionesDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluaciones(int id)
        {
            await _evaluacionesService.DeleteEvaluaciones(id);
            return NoContent();
        }
    }
}
