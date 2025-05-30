using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class DetRegistroIssn
{
    public int IdDetalle { get; set; } // Nueva clave primaria
    public int? IdRegistroIssn { get; set; }

    public int? IdRevista { get; set; }

    public string? TipoRevista { get; set; }

    public virtual RegistroIssn? IdRegistroIssnNavigation { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
