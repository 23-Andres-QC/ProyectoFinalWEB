using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task<IEnumerable<Revista>> GetAllAsync();
        Task<Revista?> GetByIdAsync(int id);
        Task<int> CreateAsync(Revista entity);
        Task<bool> UpdateAsync(Revista entity);
        Task<bool> DeleteAsync(int id);
    }
}
