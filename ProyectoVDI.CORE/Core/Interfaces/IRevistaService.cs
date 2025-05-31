using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaService
    {
        Task<IEnumerable<RevistaListDTO>> GetAllAsync();
        Task<RevistaDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(RevistaCreateDTO dto);
        Task<bool> UpdateAsync(RevistaUpdateDTO dto);
        Task<bool> ChangeEstadoAsync(int id, int estado);
    }
}
