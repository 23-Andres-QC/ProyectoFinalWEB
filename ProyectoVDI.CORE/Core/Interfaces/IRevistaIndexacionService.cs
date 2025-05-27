using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaIndexacionService
    {
        Task<IEnumerable<RevistaIndexacionListDTO>> GetRevistaIndexaciones();
        Task<RevistaIndexacionDTO?> GetRevistaIndexacionById(int id);
        Task<int> CreateRevistaIndexacion(RevistaIndexacionCreateDTO dto);
        Task<bool> UpdateRevistaIndexacion(RevistaIndexacionUpdateDTO dto);
        Task DeleteRevistaIndexacion(int id);
    }
}
