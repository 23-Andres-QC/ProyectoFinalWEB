using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateOnly? FechaCreacion { get; set; }
    }

    public class UsuarioListDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
    }

    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
    }
}