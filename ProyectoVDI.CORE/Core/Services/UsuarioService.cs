using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    // Servicio para la lógica de negocio relacionada con usuarios
    public class UsuarioService : IUsuarioService
    {
        // Repositorio de usuarios inyectado
        private readonly IUsuariosRepository _usuariosRepository;

        // Constructor que recibe el repositorio
        public UsuarioService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        // Obtiene la lista de usuarios y la transforma a DTO para la vista/listado
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

        // Obtiene un usuario por su ID y lo transforma a DTO detallado
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

        // Crea un nuevo usuario a partir de un DTO de creación
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

        // Actualiza un usuario existente a partir de un DTO de actualización
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

        // Elimina (soft delete) un usuario por su ID
        public async Task DeleteUsuario(int id)
        {
            await _usuariosRepository.DeleteAsync(id);
        }
    }
}
