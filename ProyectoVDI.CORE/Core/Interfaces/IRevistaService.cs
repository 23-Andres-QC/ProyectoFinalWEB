using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaService
    {
        Task<IEnumerable<RevistaListDTO>> GetRevistas();
        Task<RevistaDTO?> GetRevistaById(int id);
        Task<int> CreateRevista(RevistaCreateDTO dto);
        Task<bool> UpdateRevista(RevistaUpdateDTO dto);
        Task DeleteRevista(int id);

        Task<IEnumerable<RevistaFullFlatDTO>> GetRevistasFullFlat();
    }
}
