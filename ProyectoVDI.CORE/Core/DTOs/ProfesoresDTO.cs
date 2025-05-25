using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class ProfesoresDTO
    {
        public int IdProfesor { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    public class ProfesoresListDTO
    {
        public int IdProfesor { get; set; }
        public string? NombreyApellido { get; set; }
    }

    public class ProfesoresCreateDTO
    {
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    public class ProfesoresUpdateDTO
    {
        public int IdProfesor { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }
}
