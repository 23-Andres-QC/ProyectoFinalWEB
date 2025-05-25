using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolService
    {
        Task<int> CreateRol(RolCreateDTO dto);
        Task DeleteRol(int id);
        Task<RolDTO?> GetRolById(int id);
        Task<IEnumerable<RolListDTO>> GetRoles();
        Task<bool> UpdateRol(RolUpdateDTO dto);
    }
}
