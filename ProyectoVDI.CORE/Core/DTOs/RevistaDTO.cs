namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RevistaListDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Issn { get; set; }
    }

    public class RevistaDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Issn { get; set; }
    }

    // Detalle completo de revista (para GetRevistas y GetRevistasById)
    public class RevistaFullDTO
    {
        public int IdRevista { get; set; }
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallSList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? _216bEspecial { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScupus { get; set; }
        public int? Múltiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosiciónDelAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
    }

    public class RevistaCreateDTO
    {
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallSList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? _216bEspecial { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScupus { get; set; }
        public int? Múltiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosiciónDelAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
    }

    public class RevistaUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallSList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? _216bEspecial { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScupus { get; set; }
        public int? Múltiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosiciónDelAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
        public int? Estado { get; set; }
    }

    public class BulkRevistaResultDTO
    {
        public List<string> Creado { get; set; } = new();
        public List<string> Actualizado { get; set; } = new();
    }


    // DTO para registrar revistas con detalle (con 3 entidades relacionadas)

    public class RevistaCreacionDTO
    {
        public string? Issn { get; set; }
        public string? Nombre { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public int? WoSS { get; set; }
        public string? WoSEsci { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public string? AlMenosEnUnaLista { get; set; }
        public string? SoloEnUnaLista { get; set; }
        public string? Scielo { get; set; }
        public string? WoSLatam { get; set; }
        public string? Top50 { get; set; }
        public int? N { get; set; }
        public string? BeallSList { get; set; }
        public string? Mdpi { get; set; }
        public string? Insights { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
        public int? WoSTopExiste { get; set; }
        public int? WoSEsciExiste { get; set; }
        public int? ScopusExiste { get; set; }
        public int? SoloScieloExiste { get; set; }
        public int? _216bEspecial { get; set; }
        public int? LatamSinEsciExiste { get; set; }
        public int? EsciScieloSinScupus { get; set; }
        public int? Múltiple { get; set; }
        public int? MultidisciplinaryWos { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosiciónDelAutor { get; set; }
        public double? Jif { get; set; }
        public string? Country { get; set; }
        public int? MultyYAlMenosUnaLista { get; set; }
        public int? MultidisciplinaryScopus { get; set; }
        public int? MultidisciplinaryWosOScopys { get; set; }
        public int? Estado { get; set; }

        // Campos extras para RegistroISSN y DetRegistroISSN
        public int IdUsuario { get; set; }
        public string TipoRevista { get; set; } = null!;
    }


}