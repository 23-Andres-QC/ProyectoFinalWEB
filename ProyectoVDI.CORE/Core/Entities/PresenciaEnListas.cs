using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class PresenciaEnListas
{
    public int IdLista { get; set; }

    public int? IdRevista { get; set; }

    public string? AlMenosEnUnaLista { get; set; }

    public string? SoloEnUnaLista { get; set; }

    public int? _216bEspecial { get; set; }

    public string? Top50 { get; set; }

    public int? Múltiple { get; set; }

    public int? MultyYAlMenosUnaLista { get; set; }

    public string? BeallSList { get; set; }

    public string? Mdpi { get; set; }

    public string? Insights { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
