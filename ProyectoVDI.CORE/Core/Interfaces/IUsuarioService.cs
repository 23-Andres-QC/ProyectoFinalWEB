using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CreateUsuario(UsuarioCreateDTO dto);
        Task DeleteUsuario(int id);
        Task<UsuarioDTO?> GetUsuarioById(int id);
        Task<IEnumerable<UsuarioListDTO>> GetUsuarios();
        Task<bool> UpdateUsuario(UsuarioUpdateDTO dto);
        Task<UsuarioDTO?> Login(UsuarioLoginDTO dto);
        Task<bool> RecuperarContraseña(UsuarioRecuperarDTO dto);
        Task<bool> CambiarContraseña(UsuarioChangePasswordDTO dto);
        Task<IEnumerable<UsuarioListDTO>> BuscarUsuarios(string query);
        Task<SignInResponseDTO?> SignIn(SignInRequestDTO request);
        Task<IEnumerable<UsuarioReporteDTO>> GetUsuariosReporte(UsuarioReporteFiltroDTO filtro);
    }
}