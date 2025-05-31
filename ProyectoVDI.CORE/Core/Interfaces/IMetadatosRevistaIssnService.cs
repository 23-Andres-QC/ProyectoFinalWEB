using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IMetadatosRevistaIssnService
    {
        Task<IEnumerable<MetadatosRevistaIssnListDTO>> GetAllAsync();
        Task<MetadatosRevistaIssnDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(MetadatosRevistaIssnCreateDTO dto);
        Task<bool> UpdateAsync(MetadatosRevistaIssnUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
