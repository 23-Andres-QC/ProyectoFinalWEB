using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class RevistaIndexacion
{
    public int IdIndexacion { get; set; }

    public int? IdRevista { get; set; }

    public bool? Scopus { get; set; }

    public string? WoSQ { get; set; }

    public string? WoSS { get; set; }

    public bool? WoSEsci { get; set; }

    public string? EsciQ { get; set; }

    public bool? ScopusExiste { get; set; }

    public bool? WoSEsciExiste { get; set; }

    public bool? WoSTopExiste { get; set; }

    public bool? SoloScieloExiste { get; set; }

    public bool? LatamSinEsciExiste { get; set; }

    public bool? EsciScieloSinScupus { get; set; }

    public bool? Scielo { get; set; }

    public bool? WoSLatam { get; set; }

    public bool? MultidisciplinaryWos { get; set; }

    public bool? MultidisciplinaryScopus { get; set; }

    public bool? MultidisciplinaryWosOScopys { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
