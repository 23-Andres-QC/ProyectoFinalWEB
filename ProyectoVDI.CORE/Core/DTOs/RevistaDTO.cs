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
    public class RevistaFullFlatDTO
    {
        public int IdRevista { get; set; }
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Country { get; set; }
        public double? Jif { get; set; }
        public int? N { get; set; }

        // Evaluaciones
        public int IdEvaluacion { get; set; }
        public int? IdRevistaEvaluacion { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }

        // PresenciaEnListas
        public int? IdRevistaPresencia { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public int? _216bEspecial { get; set; }
        public string? Top50 { get; set; }
        public int? Multiple { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }

        // Editorial
        public int? IdRevistaEditorial { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public string? BeallSList { get; set; }

        // Autoria
        public int? IdRevistaAutoria { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionDelAutor { get; set; }

        // RevistaIndexacion
        public int? IdRevistaIndexacion { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScupus { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
    }



}
