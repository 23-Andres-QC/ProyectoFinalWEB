using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class Revista
{
    public int IdRevista { get; set; }

    public string? Nombre { get; set; }

    public string? TipoLista { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<DetRegistroRevista> DetRegistroRevista { get; set; } = new List<DetRegistroRevista>();

    public virtual ICollection<IssnsRevista> IssnsRevista { get; set; } = new List<IssnsRevista>();

    public virtual MetadatosRevistaIssn? MetadatosRevistaIssn { get; set; }

    public virtual RevistaListaCerrada? RevistaListaCerrada { get; set; }
}
