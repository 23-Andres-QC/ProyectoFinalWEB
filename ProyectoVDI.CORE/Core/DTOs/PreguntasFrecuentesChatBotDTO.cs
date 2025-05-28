using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    //get all PreguntasFrecuentesChatBot

    public class listPreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaCreacion { get; set; }
    }

    //get by id PreguntasFrecuentesChatBot
    public class GetByIdPreguntasFrecuentesChatBotDTO
    {
        
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        
    }

    //get all  PreguntasFrecuentesChatBot and answer
    public class GetPreguntasFrecuentesChatBotDTO
    {

        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }

    }

    // create PreguntasFrecuentesChatBot

    public class createPreguntasFrecuentesChatBotDTO
    {
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }

    }

    // update PreguntasFrecuentesChatBot
    public class updatePreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }

        public int? IdUsuario { get; set; }
        


    }
    // upda Estado PreguntasFrecuentesChatBot
    public class updateEstadoPreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
        public string? Estado { get; set; }
    }

    
}