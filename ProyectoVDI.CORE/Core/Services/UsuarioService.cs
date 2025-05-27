using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuarioService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<IEnumerable<UsuarioListDTO>> GetUsuarios()
        {
            var usuarios = await _usuariosRepository.GetAllAsync();

            var usuarioList = new List<UsuarioListDTO>();
            foreach (var usuario in usuarios)
            {
                usuarioList.Add(new UsuarioListDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    Correo = usuario.Correo
                });
            }

            return usuarioList;
        }

        public async Task<UsuarioDTO?> GetUsuarioById(int id)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Correo = usuario.Correo,
                IdRol = usuario.IdRol,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion
            };
        }

        public async Task<int> CreateUsuario(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                IdRol = dto.IdRol,
                Estado = 1,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now)
            };

            return await _usuariosRepository.CreateAsync(usuario);
        }

        public async Task<bool> UpdateUsuario(UsuarioUpdateDTO dto)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null) return false;

            usuario.Correo = dto.Correo;
            usuario.Contraseña = dto.Contraseña;
            usuario.IdRol = dto.IdRol;
            usuario.Estado = dto.Estado;
            usuario.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);

            await _usuariosRepository.UpdateAsync(usuario);
            return true;
        }

        public async Task DeleteUsuario(int id)
        {
            await _usuariosRepository.DeleteAsync(id);
        }
    }
}
