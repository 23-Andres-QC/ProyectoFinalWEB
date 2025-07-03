using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // =====================
    // DTO detallado para mostrar información de un usuario (GET)
    // =====================
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreyApellido { get; set; } // Nombre y apellido del profesor
        public string? Correo { get; set; }
        public int? Id_Rol { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // =====================
    // DTO para mostrar una lista de usuarios (GET)
    // =====================
    public class UsuarioListDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreyApellido { get; set; } // Nombre y apellido del profesor
        public string? Correo { get; set; }
        public int? Id_Rol { get; set; }
        public int? Estado { get; set; }
        public string? DNI { get; set; }       // ← agrega esto
        public string? Categoria { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // =====================
    // DTO para crear un usuario (POST)
    // =====================
    public class UsuarioCreateDTO
    {
        public int? Id_Profesor_Admis { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? Id_Rol { get; set; }
        public int? Estado { get; set; }
    }

    // =====================
    // DTO para actualizar un usuario (PUT)
    // =====================
    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public int? Id_Profesor_Admis { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? Id_Rol { get; set; }
        public int? Estado { get; set; }
    }

    // =====================
    // DTO para login de usuario
    // =====================
    public class UsuarioLoginDTO
    {
        public string? Correo { get; set; } // O usuario
        public string? Contraseña { get; set; }
    }

    // =====================
    // DTO para recuperación de contraseña
    // =====================
    public class UsuarioRecuperarDTO
    {
        public string? Correo { get; set; }
    }

    // =====================
    // DTO para cambio de contraseña
    // =====================
    public class UsuarioChangePasswordDTO
    {
        public int IdUsuario { get; set; }
        public string? ContraseñaActual { get; set; }
        public string? NuevaContraseña { get; set; }
        public string? ConfirmarContraseña { get; set; }
    }
}