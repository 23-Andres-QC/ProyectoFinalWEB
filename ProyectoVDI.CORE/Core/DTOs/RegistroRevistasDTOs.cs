using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RegistroRevistasListDTO
    {
        public int IdRegistro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }

    public class RegistroRevistasDetailDTO
    {
        public int IdRegistro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }

    public class RegistroRevistasCreateDTO
    {
        public int IdUsuario { get; set; }
    }

    public class RegistroRevistasUpdateDTO
    {
        public int IdRegistro { get; set; }
        public int IdUsuario { get; set; }
    }
}
