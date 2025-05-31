using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class CategoriasListDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class CategoriasDetailDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class CategoriasCreateDTO
    {
        public string? Descripcion { get; set; }
    }

    public class CategoriasUpdateDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
