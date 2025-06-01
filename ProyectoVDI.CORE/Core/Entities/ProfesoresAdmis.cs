using System;
using System.Collections.Generic;

// Clase de entidad principal para la gestión de profesores en el sistema de admisión.
// Incluye información básica del profesor, su relación con la categoría y los usuarios asociados.
namespace ProyectoVDI.CORE.Core.Entities;
public partial class ProfesoresAdmis
{
    // Propiedades principales del profesor: identificador, categoría, DNI, nombre, correo y estado.
    public int IdProfesorAdmis { get; set; }
    public int? IdCategoria { get; set; }
    public int? Dni { get; set; }
    public string? NombreyApellido { get; set; }
    public string? Correo { get; set; }
    public int? Estado { get; set; }

    // Relaciones de navegación: Categoría a la que pertenece el profesor y usuarios asociados.
    public virtual Categorias? IdCategoriaNavigation { get; set; }
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
