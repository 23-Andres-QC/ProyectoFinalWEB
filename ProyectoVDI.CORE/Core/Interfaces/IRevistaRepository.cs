using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task<int> CreateAsync(Revista entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Revista>> GetAllAsync();
        Task<Revista?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Revista entity);
    }
}