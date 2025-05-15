using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class PresenciaEnListas
{
    public int IdLista { get; set; }

    public int? IdRevista { get; set; }

    public bool? AlMenosEnUnaLista { get; set; }

    public bool? SoloEnUnaLista { get; set; }

    public bool? _216bEspecial { get; set; }

    public bool? Top50 { get; set; }

    public bool? Múltiple { get; set; }

    public bool? MultyYAlMenosUnaLista { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
