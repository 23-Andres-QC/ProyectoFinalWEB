using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IIssnsRevistaRepository
    {
        Task<int> CreateAsync(IssnsRevista entity);
        Task<IEnumerable<IssnsRevista>> GetAllAsync();
        Task<IssnsRevista?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(IssnsRevista entity);
    }
}