using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

//Hola

public partial class CalificacionChatBot
{
    public int IdFeedback { get; set; }

    public int? IdUsuario { get; set; }

    public int? Calificacion { get; set; }

    public DateTime? FechaHora { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
