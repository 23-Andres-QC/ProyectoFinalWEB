using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class DetRegistroRevistaListDTO
    {
        public int IdDetalle { get; set; }
        public int IdRegistro { get; set; }
        public int IdRevista { get; set; }
    }

    public class DetRegistroRevistaDetailDTO
    {
        public int IdDetalle { get; set; }
        public int IdRegistro { get; set; }
        public int IdRevista { get; set; }
    }

    public class DetRegistroRevistaCreateDTO
    {
        public int IdRegistro { get; set; }
        public int IdRevista { get; set; }
    }

    public class DetRegistroRevistaUpdateDTO
    {
        public int IdDetalle { get; set; }
        public int IdRegistro { get; set; }
        public int IdRevista { get; set; }
    }
}
