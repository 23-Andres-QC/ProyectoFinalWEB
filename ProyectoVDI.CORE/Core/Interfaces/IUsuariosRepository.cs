using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    internal interface IUsuariosRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario?> GetUsuarioById(int id);
        Task UpdateUsuarioAsync(Usuario usuario);
    }
}