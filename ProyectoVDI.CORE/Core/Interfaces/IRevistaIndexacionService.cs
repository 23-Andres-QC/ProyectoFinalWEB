using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaIndexacionService
    {
        Task<int> CreateRevistaIndexacion(RevistaIndexacionCreateDTO dto);
        Task DeleteRevistaIndexacion(int id);
        Task<RevistaIndexacionDTO?> GetRevistaIndexacionById(int id);
        Task<IEnumerable<RevistaIndexacionListDTO>> GetRevistaIndexaciones();
        Task<bool> UpdateRevistaIndexacion(RevistaIndexacionUpdateDTO dto);
    }
}
