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
            try
            {
                var id = await _usuarioService.CreateUsuario(dto);
                var usuarioCreado = await _usuarioService.GetUsuarioById(id);
                return CreatedAtAction(nameof(GetById), new { id }, usuarioCreado);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); // Código 409 para duplicado
            }
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

        // =====================
        // Login de usuario
        // =====================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioService.Login(dto);
            if (usuario == null) return Unauthorized("Usuario o contraseña incorrectos");
            return Ok(usuario);
        }

        // =====================
        // Recuperación de contraseña
        // =====================
        [HttpPost("recuperar")]
        public async Task<IActionResult> RecuperarContraseña([FromBody] UsuarioRecuperarDTO dto)
        {
            var resultado = await _usuarioService.RecuperarContraseña(dto);
            if (resultado)
                return Ok("Se envió la contraseña a su correo registrado.");
            else
                return BadRequest("No se encontró el correo registrado.");
        }



        // =====================
        // Cambio de contraseña
        // =====================
        [HttpPost("cambiar-contraseña")]
        public async Task<IActionResult> CambiarContraseña([FromBody] UsuarioChangePasswordDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ok = await _usuarioService.CambiarContraseña(dto);
            if (!ok) return BadRequest("No se pudo cambiar la contraseña. Verifique los datos.");
            return Ok("Contraseña actualizada correctamente");
        }

        // =====================
        // Buscar usuarios
        // =====================
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string query)
        {
            var result = await _usuarioService.BuscarUsuarios(query);
            return Ok(result);
        }

        // =====================
        // Reporte de usuarios con filtros
        // =====================
        [HttpGet("reporte")]
        public async Task<IActionResult> GetUsuariosReporte(
            [FromQuery] int? idRol,
            [FromQuery] int? estado,
            [FromQuery] DateTime? fechaInicio,
            [FromQuery] DateTime? fechaFin)
        {
            var filtro = new UsuarioReporteFiltroDTO
            {
                IdRol = idRol,
                Estado = estado,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };
            var resultado = await _usuarioService.GetUsuariosReporte(filtro);
            return Ok(resultado);
        }

        // creacion de token de autenticación para el usuario
        //api/usuario/signin

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDTO request)
        {
            var result = await _usuarioService.SignIn(request);
            if (result == null)
                return Unauthorized("Credenciales inválidas.");
            return Ok(result);
        }

    }
}