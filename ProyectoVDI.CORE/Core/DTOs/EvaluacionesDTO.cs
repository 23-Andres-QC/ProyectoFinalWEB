using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO detallado para mostrar información de una evaluación
    public class EvaluacionesDTO
    {
        public int IdEvaluacion { get; set; }
        public int? IdRevista { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
    }

    // DTO para mostrar una lista de evaluaciones (solo datos básicos)
    public class EvaluacionesListDTO
    {
        public int IdEvaluacion { get; set; }
        public int? IdRevista { get; set; }
    }

    // DTO para crear una evaluación (datos requeridos para creación)
    public class EvaluacionesCreateDTO
    {
        public int? IdRevista { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS { get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
    }

    // DTO para actualizar una evaluación (incluye ID y campos modificables)
    public class EvaluacionesUpdateDTO
    {
        public int IdEvaluacion { get; set; }
        public int? IdRevista { get; set; }
        public string? Ajg4 { get; set; }
        public string? Ajg { get; set; }
        public int? AjgS {get; set; }
        public string? Cnrs { get; set; }
        public int? CnrsS { get; set; }
        public string? Abdc { get; set; }
        public int? AbdcS { get; set; }
        public int? AjgExiste { get; set; }
        public int? CnrsExiste { get; set; }
        public int? AbdcExiste { get; set; }
    }
}
