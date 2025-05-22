using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task CreateAsync(Revista revista);
        Task DeleteAsync(int id);
        Task<List<Revista>> GetAllAsync();
        Task<Revista> GetByIdAsync(int id);
        Task UpdateAsync(Revista revista);
    }
}