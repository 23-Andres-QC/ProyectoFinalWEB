using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RolDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }

    public class RolListDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }

    public class RolCreateDTO
    {
        public string? Descripcion { get; set; }
    }

    public class RolUpdateDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
