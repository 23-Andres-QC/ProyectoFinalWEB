using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class PresenciaEnListasDTO
    {
        public int IdLista { get; set; }
        public int? IdRevista { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public int? _216bEspecial { get; set; }
        public string? Top50 { get; set; }
        public int? Multiple { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
    }

    public class PresenciaEnListasListDTO
    {
        public int IdLista { get; set; }
        public int? IdRevista { get; set; }
    }

    public class PresenciaEnListasCreateDTO
    {
        public int? IdRevista { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public int? _216bEspecial { get; set; }
        public string? Top50 { get; set; }
        public int? Multiple { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
    }

    public class PresenciaEnListasUpdateDTO
    {
        public int IdLista { get; set; }
        public int? IdRevista { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public int? _216bEspecial { get; set; }
        public string? Top50 { get; set; }
        public int? Multiple { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
    }
}
