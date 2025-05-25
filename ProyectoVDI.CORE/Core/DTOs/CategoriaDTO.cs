using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class CategoriaListDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }

    public class CategoriaCreateDTO
    {
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class CategoriaUpdateDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
