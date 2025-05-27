using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CreateUsuario(UsuarioCreateDTO dto);
        Task DeleteUsuario(int id);
        Task<UsuarioDTO?> GetUsuarioById(int id);
        Task<IEnumerable<UsuarioListDTO>> GetUsuarios();
        Task<bool> UpdateUsuario(UsuarioUpdateDTO dto);
    }
}