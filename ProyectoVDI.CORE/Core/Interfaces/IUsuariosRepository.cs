using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<List<Usuario>> GetAllAsync(); // Debe incluir la navegación a IdProfesorNavigation
        Task<Usuario?> GetByIdAsync(int id); // Debe incluir la navegación a IdProfesorNavigation
        Task<int> CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}