using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Revista
{
    public int IdRevista { get; set; }

    public string? Issn { get; set; }

    public string? Nombre { get; set; }

    public string? Country { get; set; }

    public double? Jif { get; set; }

    public int? N { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Autoria> Autoria { get; set; } = new List<Autoria>();

    public virtual Evaluaciones? Evaluaciones { get; set; }

    public virtual PresenciaEnListas? PresenciaEnListas { get; set; }

    public virtual RevistaIndexacion? RevistaIndexacion { get; set; }
}
