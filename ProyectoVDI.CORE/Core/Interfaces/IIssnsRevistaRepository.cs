using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IIssnsRevistaRepository
    {
        Task<IEnumerable<IssnsRevista>> GetAllAsync();
        Task<IssnsRevista?> GetByIdAsync(int id);
        Task<int> CreateAsync(IssnsRevista entity);
        Task<bool> UpdateAsync(IssnsRevista entity);
        Task<bool> DeleteAsync(int id);
    }
}
