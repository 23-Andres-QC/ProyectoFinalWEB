using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public int? IdRol { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public DateOnly? FechaModificacion { get; set; }

    public virtual ICollection<ChatInstitucional> ChatInstitucional { get; set; } = new List<ChatInstitucional>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<PreguntasFrecuentes> PreguntasFrecuentes { get; set; } = new List<PreguntasFrecuentes>();

    public virtual ICollection<Profesores> Profesores { get; set; } = new List<Profesores>();

    public virtual ICollection<RegistroIssn> RegistroIssn { get; set; } = new List<RegistroIssn>();
}
