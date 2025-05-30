using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class RevistaRegistroRequestDTO
    {
        public int Usuario { get; set; }
        public string TipoRevista { get; set; } = string.Empty;
        public List<RevistaCreateDTO> Revistas { get; set; } = new();
    }
}
