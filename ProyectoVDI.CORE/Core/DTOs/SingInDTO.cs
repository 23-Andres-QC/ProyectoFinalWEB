using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class SignInRequestDTO
    {
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }

    public class SignInResponseDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public string Token { get; set; } = null!;
    }
}
