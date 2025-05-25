using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RegistroIssnDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaRegistro { get; set; }
    }

    public class RegistroIssnListDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
    }

    public class RegistroIssnCreateDTO
    {
        public int? IdUsuario { get; set; }
        public DateOnly? FechaRegistro { get; set; }
    }

    public class RegistroIssnUpdateDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaRegistro { get; set; }
    }
}
