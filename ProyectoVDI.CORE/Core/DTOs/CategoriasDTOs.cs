using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO para listar categorias (vista general)
    public class CategoriasListDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    // DTO para listar categorias sin mostrar el IdCategoria
    public class CategoriasListNoIdDTO
    {
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    // DTO para mostrar el detalle de una categoria
    public class CategoriasDetailDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    // DTO para crear una nueva categoria
    public class CategoriasCreateDTO
    {
        public string? Descripcion { get; set; }
        public int? Estado { get; set; } // Permite registrar el estado manualmente
    }

    // DTO para actualizar los datos de una categoria existente
    public class CategoriasUpdateDTO
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
