using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class PreguntasFrecuentesChatBot
{
    public int IdPregunta { get; set; }

    public string? Pregunta { get; set; }

    public string? Respuesta { get; set; }

    public string? Categoria { get; set; }

    public string? Estado { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
