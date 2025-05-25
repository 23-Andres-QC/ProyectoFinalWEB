using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<int> CreateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task UpdateAsync(Usuario usuario);
    }
}