using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolRepository
    {
        int Create(Rol item);
        Task<int> CreateAsync(Rol item);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Rol> GetAll();
        Task<IEnumerable<Rol>> GetAllAsync();
        Rol GetById(int id);
        Task<Rol> GetByIdAsync(int id);
        bool Update(Rol item);
        Task<bool> UpdateAsync(Rol item);
    }
}
