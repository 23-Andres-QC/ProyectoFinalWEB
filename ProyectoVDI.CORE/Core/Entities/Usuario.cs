using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.Entities;

/*
 * Entidad que representa a un usuario en el sistema.
 * Incluye propiedades básicas y navegación a profesores, roles y otras entidades relacionadas.
 */
public partial class Usuario
{
    public int IdUsuario { get; set; }
    public int? IdProfesor { get; set; }
    public string? Correo { get; set; }
    public string? Contraseña { get; set; }
    public int? IdRol { get; set; }
    public int? Estado { get; set; }
    public DateOnly? FechaCreacion { get; set; }
    public DateOnly? FechaModificacion { get; set; }
    public virtual ICollection<CalificacionChatBot> CalificacionChatBot { get; set; } = new List<CalificacionChatBot>();
    public virtual Profesores? IdProfesorNavigation { get; set; }
    public virtual Rol? IdRolNavigation { get; set; }
    public virtual ICollection<PreguntasFrecuentesChatBot> PreguntasFrecuentesChatBot { get; set; } = new List<PreguntasFrecuentesChatBot>();
    public virtual ICollection<RegistroIssn> RegistroIssn { get; set; } = new List<RegistroIssn>();
}
