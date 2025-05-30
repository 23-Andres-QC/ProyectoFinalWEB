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
        public int? IdProfesor { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateOnly? FechaCreacion { get; set; }
        public DateOnly? FechaModificacion { get; set; }
        public string? NombreUsuario { get; set; } // Desde Profesores
    }

    // =====================
    // DTO para mostrar una lista de usuarios (GET)
    // =====================
    public class UsuarioListDTO
    {
        public int IdUsuario { get; set; }
        public int? IdProfesor { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateOnly? FechaCreacion { get; set; }
        public DateOnly? FechaModificacion { get; set; }
        public string? NombreUsuario { get; set; } // Desde Profesores
    }

    // =====================
    // DTO para crear un usuario (POST)
    // =====================
    public class UsuarioCreateDTO
    {
        public int? IdProfesor { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }

    // =====================
    // DTO para actualizar un usuario (PUT)
    // =====================
    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public int? IdProfesor { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }
}