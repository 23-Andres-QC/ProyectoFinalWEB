using System;
using System.Collections.Generic;
using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.CORE.Core.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }
    public int? Id_Profesor_Admis { get; set; }
    public string? Correo { get; set; }
    public string? Contraseña { get; set; }
    public int? Id_Rol { get; set; }
    public int? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CalificacionChatBot> CalificacionChatBot { get; set; } = new List<CalificacionChatBot>();
    public virtual ICollection<PreguntasFrecuentesChatBot> PreguntasFrecuentesChatBot { get; set; } = new List<PreguntasFrecuentesChatBot>();
    public virtual ICollection<RegistroRevistas> RegistroRevistas { get; set; } = new List<RegistroRevistas>();
    public virtual ProfesoresAdmis? IdProfesorAdmisNavigation { get; set; }
    public virtual Rol? Rol { get; set; }
}