using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class DetChatUsuario
{
    public int? IdChat { get; set; }

    public string? PreguntaUsuario { get; set; }

    public string? RespuestaSistema { get; set; }

    public DateTime? FechaHora { get; set; }

    public virtual ChatInstitucional? IdChatNavigation { get; set; }
}
