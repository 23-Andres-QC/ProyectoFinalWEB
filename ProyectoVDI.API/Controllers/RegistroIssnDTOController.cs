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
    public class RegistroIssnDTOController : ControllerBase
    {
        private readonly IRegistroIssnService _service;

        public RegistroIssnDTOController(IRegistroIssnService service)
        {
            _service = service;
        }

        // GET: api/RegistroIssnDTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registros = await _service.GetRegistroIssns();
            return Ok(registros);
        }

        // GET: api/RegistroIssnDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reg = await _service.GetRegistroIssnById(id);
            if (reg == null)
                return NotFound();
            return Ok(reg);
        }

        // POST: api/RegistroIssnDTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistroIssnCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto RegistroIssnCreateDTO es nulo.");
            if (dto.IdUsuario == null)
                return BadRequest("El campo 'IdUsuario' es obligatorio.");
            var newId = await _service.CreateRegistroIssn(dto);
            return Ok(newId);
        }

        // PUT: api/RegistroIssnDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegistroIssnUpdateDTO dto)
        {
            if (dto == null || dto.IdRegistroIssn != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (dto.IdUsuario == null)
                return BadRequest("El campo 'IdUsuario' es obligatorio.");
            var result = await _service.UpdateRegistroIssn(dto);
            if (!result)
                return NotFound();
            return Ok("Registro ISSN actualizado correctamente.");
        }

        // DELETE: api/RegistroIssnDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRegistroIssn(id);
            return NoContent();
        }
    }
}
