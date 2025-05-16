using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEditorialRepository
    {
        int Create(Editorial editorial);
        Task<int> CreateAsync(Editorial editorial);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Editorial> GetAll();
        Task<IEnumerable<Editorial>> GetAllAsync();
        Editorial GetById(int id);
        Task<Editorial> GetByIdAsync(int id);
        bool Update(Editorial editorial);
        Task<bool> UpdateAsync(Editorial editorial);
    }
}