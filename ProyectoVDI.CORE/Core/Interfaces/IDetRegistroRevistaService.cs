using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroRevistaService
    {
        Task<IEnumerable<DetRegistroRevistaListDTO>> GetAllAsync();
        Task<DetRegistroRevistaDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(DetRegistroRevistaCreateDTO dto);
        Task<bool> UpdateAsync(DetRegistroRevistaUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
