using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class CalificacionChatBotDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
    }

    public class CalificacionChatBotListDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
    }

    public class CalificacionChatBotCreateDTO
    {
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
    }

    public class CalificacionChatBotUpdateDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
    }
}
