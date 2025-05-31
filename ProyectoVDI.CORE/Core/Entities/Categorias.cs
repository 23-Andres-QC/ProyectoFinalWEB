using System;
using System.Collections.Generic;


namespace ProyectoVDI.CORE.Core.Entities;
public partial class Categorias
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<ProfesoresAdmis> ProfesoresAdmis { get; set; } = new List<ProfesoresAdmis>();
}
