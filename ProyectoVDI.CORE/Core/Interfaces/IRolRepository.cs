using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRolRepository
    {
        Task CreateAsync(Rol rol);
        Task DeleteAsync(int id);
        Task<List<Rol>> GetAllAsync();
        Task<Rol> GetByIdAsync(int id);
        Task UpdateAsync(Rol rol);
    }
}