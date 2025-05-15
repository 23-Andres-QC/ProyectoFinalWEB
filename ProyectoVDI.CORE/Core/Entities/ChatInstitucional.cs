using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class ChatInstitucional
{
    public int IdChat { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
