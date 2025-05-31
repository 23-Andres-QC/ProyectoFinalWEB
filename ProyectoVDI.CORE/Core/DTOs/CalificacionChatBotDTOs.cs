using System;

namespace ProyectoVDI.CORE.Core.DTOs
{

    //Solo calificaciones segun un usuario
    public class CalificacionChatBotListDTO
    {
        
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
      
    }

    // calificacion con todo Detalle de calificacion del chat bot
    public class CalificacionChatBotDetailDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        public DateTime? Fecha { get; set; }
    }

    //crear calificacion del chat bot
    public class CalificacionChatBotCreateDTO
    {
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
    }

    // actualizar calificacion del chat bot
    public class CalificacionChatBotUpdateDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        
    }
}
