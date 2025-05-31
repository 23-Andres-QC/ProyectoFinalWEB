using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class ProfesoresAdmis
{
    public int IdProfesorAdmis { get; set; }

    public int? IdCategoria { get; set; }

    public int? Dni { get; set; }

    public string? NombreyApellido { get; set; }

    public string? Correo { get; set; }

    public int? Estado { get; set; }

    public virtual Categorias? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
