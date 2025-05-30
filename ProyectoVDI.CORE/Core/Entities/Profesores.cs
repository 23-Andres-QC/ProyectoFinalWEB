using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

/*
 * Entidad que representa a un profesor en el sistema.
 * Incluye propiedades básicas y navegación a usuarios y categorías.
 */
public partial class Profesores
{
    public int IdProfesor { get; set; }
    public int? IdCategoria { get; set; }
    public int? Dni { get; set; }
    public string? NombreyApellido { get; set; }
    public string? Correo { get; set; }
    public int? Estado { get; set; }
    public virtual Categorias? IdCategoriaNavigation { get; set; }
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
