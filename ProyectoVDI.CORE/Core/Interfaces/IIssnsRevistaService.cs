using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IIssnsRevistaService
    {
        Task<IEnumerable<IssnsRevistaListDTO>> GetAllAsync();
        Task<IssnsRevistaDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(IssnsRevistaCreateDTO dto);
        Task<bool> UpdateAsync(IssnsRevistaUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
