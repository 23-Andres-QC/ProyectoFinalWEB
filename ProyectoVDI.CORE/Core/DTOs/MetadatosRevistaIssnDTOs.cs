using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO para listar registros de MetadatosRevistaIssn (para tabla y para GET all)
    public class MetadatosRevistaIssnListDTO
    {
        // Todos los atributos de la entidad MetadatosRevistaIssn
        public int IdRevista { get; set; }
        public string? NombreRevista { get; set; } // Solo lectura, viene de la entidad Revista
        public string? Issn { get; set; } // Nuevo campo para mostrar el ISSN principal
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

    // DTO para mostrar el detalle de un registro de MetadatosRevistaIssn
    public class MetadatosRevistaIssnDetailDTO
    {
        // Igual que el ListDTO, todos los atributos
        public int IdRevista { get; set; }
        public string? NombreRevista { get; set; } // Solo lectura, viene de la entidad Revista
        public string? Issn { get; set; } // Nuevo campo para mostrar el ISSN principal
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

    // DTO para crear un nuevo registro de MetadatosRevistaIssn
    public class MetadatosRevistaIssnCreateDTO
    {
        // Todos los atributos editables
        public int IdRevista { get; set; }
        public string? NombreRevista { get; set; } // Se usará para crear/actualizar en la entidad Revista
        public string? Issn { get; set; } // Nuevo campo para importar el ISSN
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

    // DTO para actualizar un registro existente de MetadatosRevistaIssn
    public class MetadatosRevistaIssnUpdateDTO
    {
        // Todos los atributos editables
        public int IdRevista { get; set; }
        public string? NombreRevista { get; set; } // Se usará para actualizar en la entidad Revista
        public string? Issn { get; set; } // Nuevo campo para actualizar el ISSN
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
}
