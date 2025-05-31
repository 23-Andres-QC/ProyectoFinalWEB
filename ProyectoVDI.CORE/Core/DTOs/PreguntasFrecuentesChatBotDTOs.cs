using System;

namespace ProyectoVDI.CORE.Core.DTOs
{

    // Obtener preguntas y respuestas frecuentes 

    public class GetAllPreguntasFrecuentesDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
    }
        
        
    

    // respuesta de las preguntas frecuentes del chatbot por id
    public class PreguntasFrecuentesChatBotDTObyId
    {
        public string? Respuesta { get; set; }
    }


    // Preguntas frecuentes del chatbot con detalles
    public class PreguntasFrecuentesChatBotDetailDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }

    public class PreguntasFrecuentesChatBotCreateDTO
    {
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public int? IdUsuario { get; set; }
    }


    // Actualizar todo lo relacionado a las preguntas frecuentes del chatbot
    public class PreguntasFrecuentesChatBotUpdateDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        
    }

    // Actualizar el estado de una pregunta frecuente del chatbot

    public class ActualizarEstadoPreguntaFrecuenteDTO
    {
        public int IdPregunta { get; set; }
        public string? Estado { get; set; }
    }

}