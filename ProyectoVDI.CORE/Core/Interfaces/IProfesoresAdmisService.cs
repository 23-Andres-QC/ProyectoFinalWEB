using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresAdmisService
    {
        Task<IEnumerable<ProfesoresAdmisListDTO>> GetAllAsync();
        Task<ProfesoresAdmisDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(ProfesoresAdmisCreateDTO dto);
        Task<bool> UpdateAsync(ProfesoresAdmisUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
