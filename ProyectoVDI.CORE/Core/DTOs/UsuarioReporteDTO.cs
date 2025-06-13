using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class UsuarioReporteDTO
    {
        public string? Correo { get; set; }
        public string? Descripcion { get; set; }
        public int? DNI { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    public class UsuarioReporteFiltroDTO
    {
        public int? IdRol { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
