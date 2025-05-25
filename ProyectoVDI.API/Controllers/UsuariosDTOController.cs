using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosDTOController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosDTOController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/UsuariosDTO
        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        // GET: api/UsuariosDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/UsuariosDTO
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioCreateDTO usuarioCreateDTO)
        {
            if (usuarioCreateDTO == null)
            {
                return BadRequest("El objeto UsuarioCreateDTO es nulo.");
            }

            var newId = await _usuarioService.CreateUsuario(usuarioCreateDTO);
            return Ok(newId);
        }

        // PUT: api/UsuariosDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {
            if (usuarioUpdateDTO == null || usuarioUpdateDTO.Id != id)
            {
                return BadRequest("El objeto es nulo o el ID no coincide.");
            }

            var result = await _usuarioService.UpdateUsuario(usuarioUpdateDTO);
            if (!result)
            {
                return NotFound();
            }

            return Ok("Usuario actualizado correctamente.");
        }

        // DELETE: api/UsuariosDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
