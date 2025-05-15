using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Profesores
{
    public int IdProfesor { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdUsuario { get; set; }

    public string? Dni { get; set; }

    public string? NombreApellido { get; set; }

    public string? Correo { get; set; }

    public virtual Categorias? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
