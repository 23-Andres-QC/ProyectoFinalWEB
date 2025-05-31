using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class ProfesoresAdmisListDTO
    {
        public int IdProfesorAdmis { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    public class ProfesoresAdmisDetailDTO
    {
        public int IdProfesorAdmis { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    public class ProfesoresAdmisCreateDTO
    {
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
    }

    public class ProfesoresAdmisUpdateDTO
    {
        public int IdProfesorAdmis { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }
}
