using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegistroIssnController : ControllerBase
    {

        private readonly IRegistroIssnService _service;
        public RegistroIssnController(IRegistroIssnService service)
        {
            _service = service;
        }

        // obtener todos los registros de ISSN
        // GET api/RegistroIssn/GetAllRegistroIssns

        [HttpGet("GetAllRegistroIssns")]
        public async Task<IActionResult> GetAllRegistroIssns()
        {
            var result = await _service.GetAllRegistroIssnsAsync();
            return Ok(result);
        }

        // obtener un registro de ISSN por ID
        // GET api/RegistroIssn/GetRegistroIssnById/{id}
        [HttpGet("GetRegistroIssnById/{id}")]
        public async Task<IActionResult> GetRegistroIssnById(int id)
        {
            var result = await _service.GetRegistroIssnByIdAsync(id);
            if (result == null)
            {
                return NotFound($"Registro ISSN con ID {id} no encontrado.");
            }
            return Ok(result);
        }

        // obtener registros de ISSN por fecha
        // GET api/RegistroIssn/GetRegistroIssnByFecha/{fecha}
        [HttpGet("GetRegistroIssnByFecha/{fecha}")]
        public async Task<IActionResult> GetRegistroIssnByFecha(DateOnly fecha)
        {
            var result = await _service.GetRegistroIssnByFechaAsync(fecha);
            if (result == null || !result.Any())
            {
                return NotFound($"No se encontraron registros ISSN para la fecha {fecha}.");
            }
            return Ok(result);
        }

        // crear un nuevo registro de ISSN
        // POST api/RegistroIssn/CreateRegistroIssn
        [HttpPost("CreateRegistroIssn")]
        public async Task<IActionResult> CreateRegistroIssn([FromBody] CreateRegistroIssnDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }
            var result = await _service.CreateRegistroIssnAsync(dto);
            if (result)
            {
                return CreatedAtAction(nameof(GetRegistroIssnById), new { id = dto.IdUsuario }, dto);
            }
            return BadRequest("Error al crear el registro ISSN.");
        }

        // actualizar un registro de ISSN
        // PUT api/RegistroIssn/UpdateRegistroIssn
        [HttpPut("UpdateRegistroIssn")]
        public async Task<IActionResult> UpdateRegistroIssn([FromBody] UpdateRegistroIssnDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }
            var result = await _service.UpdateRegistroIssnAsync(dto);
            if (result)
            {
                return NoContent(); // 204 No Content
            }
            return NotFound($"Registro ISSN con ID {dto.IdRegistroIssn} no encontrado para actualizar.");
        }

        // eliminar un registro de ISSN
        // DELETE api/RegistroIssn/DeleteRegistroIssn/{id}
        [HttpDelete("DeleteRegistroIssn/{id}")]
        public async Task<IActionResult> DeleteRegistroIssn(int id)
        {
            var result = await _service.DeleteRegistroIssnAsync(id); 
            if (result)
            {
                return NoContent(); // 204 No Content
            }
            return NotFound($"Registro ISSN con ID {id} no encontrado para eliminar.");
        }





    }
}
