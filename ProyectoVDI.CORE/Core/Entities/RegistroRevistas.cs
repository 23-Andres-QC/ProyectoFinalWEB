using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class RegistroRevistas
{
    public int IdRegistro { get; set; }

    public int IdUsuario { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetRegistroRevista> DetRegistroRevista { get; set; } = new List<DetRegistroRevista>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
