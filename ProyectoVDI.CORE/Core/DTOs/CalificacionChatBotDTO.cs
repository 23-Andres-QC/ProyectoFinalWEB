using System;

namespace ProyectoVDI.CORE.Core.DTOs
{


    public class CreateCalificacionChatBotDTO
    {
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }

    }



    public class ListCalificacionChatBotDTO
    {
        public int IdFeedback { get; set; }
        public int? IdUsuario { get; set; }
        public int? Calificacion { get; set; }
        public DateTime? FechaHora { get; set; }
    }

}
