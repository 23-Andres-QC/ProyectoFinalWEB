using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class RevistaIndexacion
{
    public int IdIndexacion { get; set; }

    public int? IdRevista { get; set; }

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

    public virtual Revista? IdRevistaNavigation { get; set; }
}
