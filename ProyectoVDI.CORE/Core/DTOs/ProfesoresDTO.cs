using System;
using System.Collections.Generic;

namespace ProyectoVDI.CORE.Core.DTOs
{
    /*
     * DTO detallado para mostrar información de un profesor.
     */
    public class ProfesoresDTO
    {
        public int IdProfesor { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    /*
     * DTO para mostrar una lista de profesores (solo datos básicos).
     */
    public class ProfesoresListDTO
    {
        public int IdProfesor { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Dni { get; set; }
    }

    /*
     * DTO para crear un profesor.
     */
    public class ProfesoresCreateDTO
    {
        public int IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    /*
     * DTO para actualizar un profesor.
     */
    public class ProfesoresUpdateDTO
    {
        public int IdProfesor { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }
}
