using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Editorial
{
    public int IdEditorial { get; set; }

    public int? IdRevista { get; set; }

    public bool? Mdpi { get; set; }

    public bool? Insights { get; set; }

    public bool? BeallSList { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
