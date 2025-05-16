using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Editorial 
{
    public int IdEditorial { get; set; }

    public int? IdRevista { get; set; }

    public string? Mdpi { get; set; }

    public string? Insights { get; set; }

    public string? BeallSList { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
