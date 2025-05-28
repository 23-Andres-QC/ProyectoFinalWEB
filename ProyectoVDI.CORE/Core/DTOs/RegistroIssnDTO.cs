using System;

namespace ProyectoVDI.CORE.Core.DTOs
{

    public class RegistroIssnDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaRegistro { get; set; }
    }
    public class ListAllRegistroIssnDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaRegistro { get; set; }
    }

    public class CreateRegistroIssnDTO
    {
        public int? IdUsuario { get; set; }
    }

    public class UpdateRegistroIssnDTO
    {
        public int IdRegistroIssn { get; set; }
        public int? IdUsuario { get; set; }
        
    }

    public class deleteRegistroIssnDTO
    {
        public int IdRegistroIssn { get; set; }
    }
}
