using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class ListaCerradaRegistroDTO
    {
        public string ISSN { get; set; } = string.Empty;
        public string ISSN2 { get; set; } = string.Empty;
        public string ISSN3 { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Categoria2 { get; set; } = string.Empty;
        public double? Puntaje { get; set; }
        public int? IncentivoUSD { get; set; }
        public string SCOPUS { get; set; } = string.Empty;
        public string WoS_Q { get; set; } = string.Empty;
        public string ESCI_Q { get; set; } = string.Empty;
        public string AJG { get; set; } = string.Empty;
        public string CNRS { get; set; } = string.Empty;
        public string ABDC { get; set; } = string.Empty;
        public string WoS_LATAM { get; set; } = string.Empty;
    }
}
