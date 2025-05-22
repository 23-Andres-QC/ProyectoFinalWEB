using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEditorialRepository
    {
        Task<int> CreateAsync(Editorial editorial);
        Task DeleteAsync(int id);
        Task<List<Editorial>> GetAllAsync();
        Task<Editorial> GetByIdAsync(int id);
        Task UpdateAsync(Editorial editorial);
    }
}