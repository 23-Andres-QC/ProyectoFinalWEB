using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // =====================
    // Controlador para la gestión de usuarios
    // =====================
    public class UsuarioController : ControllerBase
    {
        // Servicio de usuario inyectado
        private readonly IUsuarioService _usuarioService;

        // Constructor que recibe el servicio
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // =====================
        // Obtiene todos los usuarios
        // =====================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usuarioService.GetUsuarios();
            // La respuesta ya incluye NombreUsuario y no incluye Estado
            return Ok(result);
        }

        // =====================
        // Obtiene un usuario por su ID
        // =====================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usuarioService.GetUsuarioById(id);
            if (result == null) return NotFound();
            // La respuesta ya incluye NombreUsuario y no incluye Estado
            return Ok(result);
        }

        // =====================
        // Crea un nuevo usuario
        // =====================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDTO dto)
        {
            // Validación de modelo
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _usuarioService.CreateUsuario(dto);
            // Devuelve el usuario creado con su nombre
            var usuarioCreado = await _usuarioService.GetUsuarioById(id);
            return CreatedAtAction(nameof(GetById), new { id }, usuarioCreado);
        }

        // =====================
        // Actualiza un usuario existente
        // =====================
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsuarioUpdateDTO dto)
        {
            // Validación de modelo
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _usuarioService.UpdateUsuario(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // =====================
        // Elimina (soft delete) un usuario por su ID
        // =====================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}