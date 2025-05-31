using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class UsuarioListDTO
    {
        public int IdUsuario { get; set; }
        public int? IdProfesorAdmis { get; set; }
        public string? Correo { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }

    public class UsuarioDetailDTO
    {
        public int IdUsuario { get; set; }
        public int? IdProfesorAdmis { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public int? IdProfesorAdmis { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
    }

    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public int? IdProfesorAdmis { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }
}
