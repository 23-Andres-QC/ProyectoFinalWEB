using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Evaluaciones
{
    public int IdEvaluacion { get; set; }

    public int? IdRevista { get; set; }

    public bool? Ajg4 { get; set; }

    public string? Ajg { get; set; }

    public string? AjgS { get; set; }

    public string? Cnrs { get; set; }

    public string? CnrsS { get; set; }

    public string? Abdc { get; set; }

    public string? AbdcS { get; set; }

    public bool? AjgExiste { get; set; }

    public bool? CnrsExiste { get; set; }

    public bool? AbdcExiste { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
