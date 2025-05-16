using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

// bienvenido a autoria//
// ESTE COMENTARIO ES PARA MI BRANCH DE PRUEBAS remota

public partial class Autoria
{
    public int IdAutoria { get; set; }

    public int? IdRevista { get; set; }

    public string? CoautoriaEsan { get; set; }

    public string? PosiciónDelAutor { get; set; }

    public virtual Revista? IdRevistaNavigation { get; set; }
}
