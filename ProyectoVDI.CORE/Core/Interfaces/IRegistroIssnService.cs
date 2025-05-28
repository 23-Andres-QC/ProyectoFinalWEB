using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroIssnService
    {
        // crud

        //crear una interfaz para el servicio de RegistroIssn
        Task<bool> CreateRegistroIssnAsync(CreateRegistroIssnDTO dto);

        // Obtener todos los registros de ISSN
        Task<IEnumerable<ListAllRegistroIssnDTO>> GetAllRegistroIssnsAsync();

        // Obtener un registro de ISSN por ID
        Task<RegistroIssnDTO> GetRegistroIssnByIdAsync(int id);

        // Obtener registros de ISSN por fecha
        Task<IEnumerable<ListAllRegistroIssnDTO>> GetRegistroIssnByFechaAsync(DateOnly fecha);


        // Actualizar un registro de ISSN
        Task<bool> UpdateRegistroIssnAsync(UpdateRegistroIssnDTO dto);

        // Eliminar un registro de ISSN
        Task<bool> DeleteRegistroIssnAsync(int id);



    }
}
