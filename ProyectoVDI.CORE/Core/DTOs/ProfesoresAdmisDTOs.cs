using System;

namespace ProyectoVDI.CORE.Core.DTOs
{
    // DTO para listar profesores (vista general)
    public class ProfesoresAdmisListDTO
    {
        public int IdProfesorAdmis { get; set; }
        public int? IdCateg { get; set; } // ahora vuelve mas la categoria id
        public string? Categoria { get; set; } // Ahora muestra la descripción de la categoría
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public string? Estado { get; set; }
    }

    // DTO para mostrar el detalle de un profesor
    public class ProfesoresAdmisDetailDTO
    {
        public int IdProfesorAdmis { get; set; }
        public string? IdCategoria { get; set; } // Ahora muestra la descripción de la categoría
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }

    // DTO para crear un nuevo profesor (ahora incluye Estado)
    public class ProfesoresAdmisCreateDTO
    {
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; } // Permite registrar el estado manualmente o por importación
    }

    // DTO para actualizar los datos de un profesor existente
    public class ProfesoresAdmisUpdateDTO
    {
        public int IdProfesorAdmis { get; set; }
        public int? IdCategoria { get; set; }
        public int? Dni { get; set; }
        public string? NombreyApellido { get; set; }
        public string? Correo { get; set; }
        public string? Estado { get; set; }
    }
}
