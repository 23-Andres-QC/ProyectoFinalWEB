using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.Setting;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoVDI.CORE.Infrastructure.Shared
{
    public class JWTService : IJWTService

    {
        public JWTSettings _settings { get; }

        
        public JWTService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWToken(Usuario user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Correo ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Correo ?? string.Empty),
                new Claim("UserId", user.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, user.IdRol?.ToString() ?? "User")
            };

            var payload = new JwtPayload(
                _settings.Issuer,
                _settings.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
