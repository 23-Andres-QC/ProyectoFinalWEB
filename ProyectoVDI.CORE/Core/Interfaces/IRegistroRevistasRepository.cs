using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroRevistasRepository
    {
        Task<IEnumerable<RegistroRevistas>> GetAllAsync();
        Task<RegistroRevistas?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegistroRevistas entity);
        Task<bool> UpdateAsync(RegistroRevistas entity);
        Task<bool> DeleteAsync(int id);
    }
}
