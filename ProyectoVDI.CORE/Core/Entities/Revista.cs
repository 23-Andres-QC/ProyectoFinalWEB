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

    public virtual ICollection<Autoria> Autoria { get; set; } = new List<Autoria>();

    public virtual ICollection<Editorial> Editorial { get; set; } = new List<Editorial>();

    public virtual ICollection<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();

    public virtual ICollection<PresenciaEnListas> PresenciaEnListas { get; set; } = new List<PresenciaEnListas>();

    public virtual ICollection<RevistaIndexacion> RevistaIndexacion { get; set; } = new List<RevistaIndexacion>();
}
