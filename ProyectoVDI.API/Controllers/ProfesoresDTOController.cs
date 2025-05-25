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
    public class ProfesoresDTOController : ControllerBase
    {
        private readonly IProfesoresService _profesoresService;

        public ProfesoresDTOController(IProfesoresService profesoresService)
        {
            _profesoresService = profesoresService;
        }

        // GET: api/ProfesoresDTO
        [HttpGet]
        public async Task<IActionResult> GetAllProfesores()
        {
            var profesores = await _profesoresService.GetProfesores();
            return Ok(profesores);
        }

        // GET: api/ProfesoresDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesoresById(int id)
        {
            var profesor = await _profesoresService.GetProfesoresById(id);
            if (profesor == null)
                return NotFound();
            return Ok(profesor);
        }

        // POST: api/ProfesoresDTO
        [HttpPost]
        public async Task<IActionResult> CreateProfesores([FromBody] ProfesoresCreateDTO profesoresCreateDTO)
        {
            if (profesoresCreateDTO == null)
                return BadRequest("El objeto ProfesoresCreateDTO es nulo.");
            if (string.IsNullOrWhiteSpace(profesoresCreateDTO.NombreyApellido))
                return BadRequest("El campo 'NombreyApellido' es obligatorio.");
            var newId = await _profesoresService.CreateProfesores(profesoresCreateDTO);
            return Ok(newId);
        }

        // PUT: api/ProfesoresDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesores(int id, [FromBody] ProfesoresUpdateDTO profesoresUpdateDTO)
        {
            if (profesoresUpdateDTO == null || profesoresUpdateDTO.IdProfesor != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (string.IsNullOrWhiteSpace(profesoresUpdateDTO.NombreyApellido))
                return BadRequest("El campo 'NombreyApellido' es obligatorio.");
            var result = await _profesoresService.UpdateProfesores(profesoresUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Profesor actualizado correctamente.");
        }

        // DELETE: api/ProfesoresDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesores(int id)
        {
            await _profesoresService.DeleteProfesores(id);
            return NoContent();
        }
    }
}
