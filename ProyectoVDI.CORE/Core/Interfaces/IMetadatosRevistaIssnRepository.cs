using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    // Interfaz para el repositorio de MetadatosRevistaIssn
    public interface IMetadatosRevistaIssnRepository
    {
        // Obtiene todos los registros para visualización en tabla
        Task<IEnumerable<MetadatosRevistaIssn>> GetAllAsync();
        // Obtiene el detalle de un registro por su ID
        Task<MetadatosRevistaIssn?> GetByIdAsync(int id);
        // Crea un nuevo registro
        Task<int> CreateAsync(MetadatosRevistaIssn entity);
        // Actualiza un registro existente
        Task<bool> UpdateAsync(MetadatosRevistaIssn entity);
        // No se permite eliminar registros, por lo que no hay método DeleteAsync
    }
}
