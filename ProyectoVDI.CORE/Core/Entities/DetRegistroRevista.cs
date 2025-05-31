using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class DetRegistroRevista
{
    public int IdDetalle { get; set; }

    public int IdRegistro { get; set; }

    public int IdRevista { get; set; }

    public virtual RegistroRevistas IdRegistroNavigation { get; set; } = null!;

    public virtual Revista IdRevistaNavigation { get; set; } = null!;
}
