using System;

namespace ProyectoVDI.CORE.Core.DTOs
{

    // respuest solo para administrador
    public class PreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        public int? IdUsuario { get; set; }
        public DateOnly? FechaCreacion { get; set; }
    }

    // obtener pregunta y respuesta para el chat bot
    public class PreguntasFrecuentesChatBotListDTO
    {
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
    }

    // obtener solo respuesta para el chat bot
    public class PreguntasFrecuentesChatBotResponseDTO
    {
        public string? Respuesta { get; set; }
    }

    //CREAR una pregunta frecuente del chat bot

    public class PreguntasFrecuentesChatBotCreateDTO
    {
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public int? IdUsuario { get; set; }


    }

    // actualizar una pregunta frecuente del chat bot
    public class PreguntasFrecuentesChatBotUpdateDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        public int? IdUsuario { get; set; }
    }

    // actualizar el estado de una pregunta frecuente del chat bot
    public class UpdateEstadoPreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
        public string? Estado { get; set; }
    }

    // eliminar una pregunta frecuente del chat bot por id
    public class DeletePreguntasFrecuentesChatBotDTO
    {
        public int IdPregunta { get; set; }
    }

}