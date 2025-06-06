using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO for ISSN
    public class IssnRevistaDTO
    {
        public string Issn { get; set; } = string.Empty;
    }

    // DTO for MetadatosRevistaISSN
    public class MetadatosRevistaIssnDTO
    {
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4star { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosUnaLista { get; set; }
        public string? SoloUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallsList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? Especial216b { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScopus { get; set; }
        public int? Multiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
    }

    // DTO for Revista registration (single)
    public class RevistaRegistroDTO
    {
        public string ISSN { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4star { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosUnaLista { get; set; }
        public string? SoloUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallsList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? Especial216b { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScopus { get; set; }
        public int? Multiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
    }

    // DTO for batch registration
    public class RegistroRevistasBatchDTO
    {
        public int IdUsuario { get; set; }
        public string TipoRevista { get; set; } = string.Empty;
        public List<RevistaRegistroDTO> Revistas { get; set; } = new List<RevistaRegistroDTO>();
    }

    // DTO for update (by ISSN)
    public class RevistaUpdateDTO
    {
        public string Issn { get; set; } = string.Empty;
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public MetadatosRevistaIssnDTO? Metadatos { get; set; }
    }

    // DTO para GET campos básicos
    public class RevistaBasicaDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string TipoLista { get; set; } = string.Empty;
        public string Issn { get; set; } = string.Empty;
    }
}
