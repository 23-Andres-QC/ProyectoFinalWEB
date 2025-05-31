using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolListDTO>> GetAllAsync();
        Task<RolDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(RolCreateDTO dto);
        Task<bool> UpdateAsync(RolUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
