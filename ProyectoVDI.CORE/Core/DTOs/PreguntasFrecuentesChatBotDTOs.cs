using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class PreguntasFrecuentesChatBotListDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
    }

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

    public class PreguntasFrecuentesChatBotUpdateDTO
    {
        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
    }
}
