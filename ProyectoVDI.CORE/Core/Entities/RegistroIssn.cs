using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class RegistroIssn
{
    public int IdRegistroIssn { get; set; }

    public int? IdUsuario { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
