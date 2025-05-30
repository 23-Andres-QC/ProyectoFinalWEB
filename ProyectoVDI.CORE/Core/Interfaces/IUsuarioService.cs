using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CreateUsuario(UsuarioCreateDTO dto);
        Task DeleteUsuario(int id);
        Task<UsuarioDTO?> GetUsuarioById(int id); // Incluye IdProfesor
        Task<IEnumerable<UsuarioListDTO>> GetUsuarios(); // Incluye IdProfesor
        Task<bool> UpdateUsuario(UsuarioUpdateDTO dto);
    }
}