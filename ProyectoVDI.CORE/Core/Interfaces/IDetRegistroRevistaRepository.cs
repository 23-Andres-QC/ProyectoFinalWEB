using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroRevistaRepository
    {
        Task<IEnumerable<DetRegistroRevista>> GetAllAsync();
        Task<DetRegistroRevista?> GetByIdAsync(int id);
        Task<int> CreateAsync(DetRegistroRevista entity);
        Task<bool> UpdateAsync(DetRegistroRevista entity);
        Task<bool> DeleteAsync(int id);
    }
}
