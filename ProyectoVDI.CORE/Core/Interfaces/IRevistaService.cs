using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaService
    {
        Task<int> CreateRevista(RevistaCreateDTO dto);
        Task DeleteRevista(int id);
        Task<RevistaDTO?> GetRevistaById(int id);
        Task<IEnumerable<RevistaListDTO>> GetRevistas();
        Task<bool> UpdateRevista(RevistaUpdateDTO dto);
    }
}
