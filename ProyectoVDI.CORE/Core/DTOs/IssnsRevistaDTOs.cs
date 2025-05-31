using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    public class IssnsRevistaListDTO
    {
        public int IdIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? Issn { get; set; }
    }

    public class IssnsRevistaDetailDTO
    {
        public int IdIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? Issn { get; set; }
    }

    public class IssnsRevistaCreateDTO
    {
        public int? IdRevista { get; set; }
        public string? Issn { get; set; }
    }

    public class IssnsRevistaUpdateDTO
    {
        public int IdIssn { get; set; }
        public int? IdRevista { get; set; }
        public string? Issn { get; set; }
    }
}
