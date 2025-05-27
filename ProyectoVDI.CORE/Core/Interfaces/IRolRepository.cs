using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<int> CreateAsync(Rol rol);
        Task<List<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(int id);
    }
}