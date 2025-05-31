using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioListDTO>> GetAllAsync();
        Task<UsuarioDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(UsuarioCreateDTO dto);
        Task<bool> UpdateAsync(UsuarioUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
