using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    // Interfaz para el servicio de MetadatosRevistaIssn
    public interface IMetadatosRevistaIssnService
    {
        // Obtiene todos los registros para visualización en tabla
        Task<IEnumerable<MetadatosRevistaIssnListDTO>> GetAllAsync();
        // Obtiene el detalle de un registro por su ID
        Task<MetadatosRevistaIssnDetailDTO?> GetByIdAsync(int id);
        // Crea un nuevo registro
        Task<int> CreateAsync(MetadatosRevistaIssnCreateDTO dto);
        // Actualiza un registro existente
        Task<bool> UpdateAsync(MetadatosRevistaIssnUpdateDTO dto);
        // No se permite eliminar registros, por lo que no hay método DeleteAsync
    }
}
