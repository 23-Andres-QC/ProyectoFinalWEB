using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class PreguntasFrecuentes
{
    public int IdPregunta { get; set; }

    public string? Pregunta { get; set; }

    public string? Respuesta { get; set; }

    public string? Categoria { get; set; }

    public string? Estado { get; set; }

    public int? Usuario { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int? VecesUsada { get; set; }

    public virtual Usuario? UsuarioNavigation { get; set; }
}
