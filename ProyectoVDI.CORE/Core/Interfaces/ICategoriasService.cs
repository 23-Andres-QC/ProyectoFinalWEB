using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriasService
    {
        Task<IEnumerable<CategoriasListDTO>> GetAllAsync();
        Task<CategoriasDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CategoriasCreateDTO dto);
        Task<bool> UpdateAsync(CategoriasUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
