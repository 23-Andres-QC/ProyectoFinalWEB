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
    public class RolDTOController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolDTOController(IRolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/RolDTO
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _rolService.GetRoles();
            return Ok(roles);
        }

        // GET: api/RolDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            var rol = await _rolService.GetRolById(id);
            if (rol == null)
                return NotFound();
            return Ok(rol);
        }

        // POST: api/RolDTO
        [HttpPost]
        public async Task<IActionResult> CreateRol([FromBody] RolCreateDTO rolCreateDTO)
        {
            if (rolCreateDTO == null)
                return BadRequest("El objeto RolCreateDTO es nulo.");
            if (string.IsNullOrWhiteSpace(rolCreateDTO.Descripcion))
                return BadRequest("El campo 'Descripcion' es obligatorio.");
            var newId = await _rolService.CreateRol(rolCreateDTO);
            return Ok(newId);
        }

        // PUT: api/RolDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, [FromBody] RolUpdateDTO rolUpdateDTO)
        {
            if (rolUpdateDTO == null || rolUpdateDTO.IdRol != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (string.IsNullOrWhiteSpace(rolUpdateDTO.Descripcion))
                return BadRequest("El campo 'Descripcion' es obligatorio.");
            var result = await _rolService.UpdateRol(rolUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Rol actualizado correctamente.");
        }

        // DELETE: api/RolDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            await _rolService.DeleteRol(id);
            return NoContent();
        }
    }
}
