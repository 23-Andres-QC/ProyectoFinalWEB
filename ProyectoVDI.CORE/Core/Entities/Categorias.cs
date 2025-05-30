using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

/*
 * Entidad que representa una categoría de profesores.
 * Incluye propiedades básicas y navegación a profesores asociados.
 */
public partial class Categorias
{
    public int IdCategoria { get; set; }
    public string? Descripcion { get; set; }
    public int? Estado { get; set; }
    public virtual ICollection<Profesores> Profesores { get; set; } = new List<Profesores>();
}
