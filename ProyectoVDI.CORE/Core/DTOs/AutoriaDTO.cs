using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class AutoriaDTO
    {
        public int IdAutoria { get; set; }
        public int? IdRevista { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionDelAutor { get; set; }
    }

    public class AutoriaListDTO
    {
        public int IdAutoria { get; set; }
        public int? IdRevista { get; set; }
    }

    public class AutoriaCreateDTO
    {
        public int? IdRevista { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionDelAutor { get; set; }
    }

    public class AutoriaUpdateDTO
    {
        public int IdAutoria { get; set; }
        public int? IdRevista { get; set; }
        public string? CoautoriaEsan { get; set; }
        public string? PosicionDelAutor { get; set; }
    }
}
