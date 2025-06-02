using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Setting;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }
        string GenerateJWToken(Usuario user);
    }
}