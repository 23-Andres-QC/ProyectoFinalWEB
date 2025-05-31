using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroRevistasService
    {
        Task<IEnumerable<RegistroRevistasListDTO>> GetAllAsync();
        Task<RegistroRevistasDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegistroRevistasCreateDTO dto);
        Task<bool> UpdateAsync(RegistroRevistasUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
