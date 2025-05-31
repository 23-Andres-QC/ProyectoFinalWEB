using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RevistaListDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
    }

    public class RevistaDetailDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
        // Agrega aquí campos importantes adicionales si es necesario
    }

    public class RevistaCreateDTO
    {
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
    }

    public class RevistaUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
    }

    public class RevistaChangeEstadoDTO
    {
        public int IdRevista { get; set; }
        public int Estado { get; set; }
    }
}
