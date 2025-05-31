using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RevistaListaCerradaListDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public double? Puntaje { get; set; }
        public int? IncentivoUsd { get; set; }
    }

    public class RevistaListaCerradaDetailDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public double? Puntaje { get; set; }
        public int? IncentivoUsd { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public string? Abdc { get; set; }
        public string? WoSLatam { get; set; }
    }

    public class RevistaListaCerradaCreateDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public double? Puntaje { get; set; }
        public int? IncentivoUsd { get; set; }
    }

    public class RevistaListaCerradaUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public double? Puntaje { get; set; }
        public int? IncentivoUsd { get; set; }
    }
}
