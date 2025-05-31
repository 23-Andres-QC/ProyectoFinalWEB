using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class IssnsRevista
{
    public int IdIssn { get; set; }

    public int? IdRevista { get; set; }

    public string? Issn { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
