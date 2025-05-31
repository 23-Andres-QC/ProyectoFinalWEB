using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RolListDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class RolDetailDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }

    public class RolCreateDTO
    {
        public string? Descripcion { get; set; }
    }

    public class RolUpdateDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
