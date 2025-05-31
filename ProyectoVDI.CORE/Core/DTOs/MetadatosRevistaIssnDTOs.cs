using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class MetadatosRevistaIssnListDTO
    {
        public int IdRevista { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? WoSEsci { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public string? Abdc { get; set; }
    }

    public class MetadatosRevistaIssnDetailDTO
    {
        public int IdRevista { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4star { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public string? Abdc { get; set; }
        public string? AlMenosUnaLista { get; set; }
        public string? SoloUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public string? BeallsList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
    }

    public class MetadatosRevistaIssnCreateDTO
    {
        public int IdRevista { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? WoSEsci { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public string? Abdc { get; set; }
    }

    public class MetadatosRevistaIssnUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? WoSEsci { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public string? Abdc { get; set; }
    }
}
