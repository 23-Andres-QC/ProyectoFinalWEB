using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Feedback
{
    public int IdFeedback { get; set; }

    public int? IdChat { get; set; }

    public int? Calificacion { get; set; }

    public DateTime? FechaHora { get; set; }

    public virtual ChatInstitucional? IdChatNavigation { get; set; }
}
