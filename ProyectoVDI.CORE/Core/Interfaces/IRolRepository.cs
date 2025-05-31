using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<int> CreateAsync(Rol entity);
        Task<bool> UpdateAsync(Rol entity);
        Task<bool> DeleteAsync(int id);
    }
}
