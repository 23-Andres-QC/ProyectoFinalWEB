using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class DetRegistroIssnDTO
    {
        public int? IdRegistroIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? IdTipo { get; set; }
    }

    public class DetRegistroIssnListDTO
    {
        public int? IdRegistroIssn { get; set; }
        public int? IdRevista { get; set; }
    }

    public class DetRegistroIssnCreateDTO
    {
        public int? IdRegistroIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? IdTipo { get; set; }
    }

    public class DetRegistroIssnUpdateDTO
    {
        public int? IdRegistroIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? IdTipo { get; set; }
    }
}
