using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class EditorialDTO
    {
        public int IdEditorial { get; set; }
        public int? IdRevista { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public string? BeallSList { get; set; }
    }

    public class EditorialListDTO
    {
        public int IdEditorial { get; set; }
        public int? IdRevista { get; set; }
    }

    public class EditorialCreateDTO
    {
        public int? IdRevista { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public string? BeallSList { get; set; }
    }

    public class EditorialUpdateDTO
    {
        public int IdEditorial { get; set; }
        public int? IdRevista { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public string? BeallSList { get; set; }
    }
}
