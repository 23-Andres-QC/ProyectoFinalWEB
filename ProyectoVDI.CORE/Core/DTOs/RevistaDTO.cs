using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RevistaDTO
    {
        public int IdRevista { get; set; }
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Country { get; set; }
        public double? Jif { get; set; }
        public int? N { get; set; }
    }

    public class RevistaListDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Issn { get; set; }
    }

    public class RevistaCreateDTO
    {
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Country { get; set; }
        public double? Jif { get; set; }
        public int? N { get; set; }
    }

    public class RevistaUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Country { get; set; }
        public double? Jif { get; set; }
        public int? N { get; set; }
    }
}
