using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO detallado para mostrar información de un usuario
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateOnly? FechaCreacion { get; set; }
    }

    // DTO para mostrar una lista de usuarios (solo datos básicos)
    public class UsuarioListDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
    }

    // DTO para crear un usuario (datos requeridos para creación)
    public class UsuarioCreateDTO
    {
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
    }

    // DTO para actualizar un usuario (incluye ID y campos modificables)
    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }
}