using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Repositories;
using ProyectoVDI.CORE.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    // =====================
    // Servicio para la lógica de negocio relacionada con usuarios
    // =====================


    public class UsuarioService : IUsuarioService
    {
        // Repositorio de usuarios inyectado
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTService _jwtService;

        // Constructor que recibe el repositorio
        public UsuarioService(IUsuariosRepository usuariosRepository, IJWTService service)
        {
            _usuariosRepository = usuariosRepository;
            _jwtService = service;
        }



        // metodo SingIn para autenticar usuarios y generar un token JWT

        public async Task<SignInResponseDTO?> SignIn(SignInRequestDTO request)
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u =>
                u.Correo == request.Correo &&
                u.Contraseña == request.Contraseña &&
                (u.Estado == 1 || u.Estado == null)
            );
            if (usuario == null)
                return null;
            var token = _jwtService.GenerateJWToken(usuario);
            return new SignInResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreyApellido = usuario.IdProfesorAdmisNavigation?.NombreyApellido,
                Correo = usuario.Correo,
                IdRol = usuario.Id_Rol,
                Estado = usuario.Estado,
                Token = token
            };
        }

        // =====================
        // Obtiene la lista de usuarios y la transforma a DTO para la vista/listado (GET)
        // =====================
        public async Task<IEnumerable<UsuarioListDTO>> GetUsuarios()
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuarioList = new List<UsuarioListDTO>();
            foreach (var usuario in usuarios)
            {
                usuarioList.Add(new UsuarioListDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    NombreyApellido = usuario.IdProfesorAdmisNavigation?.NombreyApellido,
                    Correo = usuario.Correo,
                    DNI = usuario.IdProfesorAdmisNavigation?.DNI?.ToString(),                   
                    Categoria = usuario.IdProfesorAdmisNavigation?.IdCategoriaNavigation?.Descripcion
                });
            }
            return usuarioList;
        }

        // =====================
        // Obtiene un usuario por su ID y lo transforma a DTO detallado (GET)
        // =====================
        public async Task<UsuarioDTO?> GetUsuarioById(int id)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(id);
            if (usuario == null) return null;
            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreyApellido = usuario.IdProfesorAdmisNavigation?.NombreyApellido,
                Correo = usuario.Correo,
                Id_Rol = usuario.Id_Rol,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion,
                FechaModificacion = usuario.FechaModificacion
            };
        }

        // =====================
        // Crea un nuevo usuario a partir de un DTO de creación (POST)
        // =====================
        public async Task<int> CreateUsuario(UsuarioCreateDTO dto)
        {
            var yaExiste = (await _usuariosRepository.GetAllAsync())
       .Any(u => u.Id_Profesor_Admis == dto.Id_Profesor_Admis);

            if (yaExiste)
                throw new Exception("Este profesor ya está registrado como usuario.");

            var usuario = new Usuario
            {
                Id_Profesor_Admis = dto.Id_Profesor_Admis, // Corregido: Usar el nombre correcto de la propiedad
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                Id_Rol = dto.Id_Rol,
                Estado = dto.Estado ?? 1, // Usa el estado proporcionado o 1 por defecto
                FechaCreacion = DateTime.Now
            };

            return await _usuariosRepository.CreateAsync(usuario);
        }

        // =====================
        // Actualiza un usuario existente a partir de un DTO de actualización (PUT)
        // =====================
        public async Task<bool> UpdateUsuario(UsuarioUpdateDTO dto)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null) return false;

            usuario.Id_Profesor_Admis = dto.Id_Profesor_Admis;
            usuario.Correo = dto.Correo;
            usuario.Contraseña = dto.Contraseña;
            usuario.Id_Rol = dto.Id_Rol;
            usuario.Estado = dto.Estado ?? usuario.Estado; // Permite actualizar el estado
            usuario.FechaModificacion = DateTime.Now;

            await _usuariosRepository.UpdateAsync(usuario);
            return true;
        }

        // =====================
        // Elimina (soft delete) un usuario por su ID
        // =====================
        public async Task DeleteUsuario(int id)
        {
            await _usuariosRepository.DeleteAsync(id);
        }

        // =====================
        // Login de usuario
        // =====================
        public async Task<UsuarioDTO?> Login(UsuarioLoginDTO dto)
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.Find(u => (u.Correo == dto.Correo) && u.Contraseña == dto.Contraseña);
            if (usuario == null) return null;
            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreyApellido = usuario.IdProfesorAdmisNavigation?.NombreyApellido,
                Correo = usuario.Correo,
                Id_Rol = usuario.Id_Rol,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion,
                FechaModificacion = usuario.FechaModificacion
            };
        }

        // =====================
        // Recuperación de contraseña (simulado)
        // =====================
        public async Task<bool> RecuperarContraseña(UsuarioRecuperarDTO dto)
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.Find(u => u.Correo == dto.Correo);
            return usuario != null;
        }

        // =====================
        // Cambio de contraseña
        // =====================
        public async Task<bool> CambiarContraseña(UsuarioChangePasswordDTO dto)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null) return false;
            if (usuario.Contraseña != dto.ContraseñaActual) return false;
            if (dto.NuevaContraseña != dto.ConfirmarContraseña) return false;
            usuario.Contraseña = dto.NuevaContraseña;
            usuario.FechaModificacion = DateTime.Now;
            await _usuariosRepository.UpdateAsync(usuario);
            return true;
        }

        // =====================
        // Buscar usuarios por correo, nombre o apellidos
        // =====================
        public async Task<IEnumerable<UsuarioListDTO>> BuscarUsuarios(string query)
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            var resultado = usuarios.FindAll(u =>
                (u.Correo != null && u.Correo.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (u.IdProfesorAdmisNavigation != null && u.IdProfesorAdmisNavigation.NombreyApellido != null && u.IdProfesorAdmisNavigation.NombreyApellido.Contains(query, StringComparison.OrdinalIgnoreCase))
            );
            var usuarioList = new List<UsuarioListDTO>();
            foreach (var usuario in resultado)
            {
                usuarioList.Add(new UsuarioListDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    NombreyApellido = usuario.IdProfesorAdmisNavigation?.NombreyApellido,
                    Correo = usuario.Correo,
                    Id_Rol = usuario.Id_Rol,
                    Estado = usuario.Estado,
                    FechaCreacion = usuario.FechaCreacion,
                    FechaModificacion = usuario.FechaModificacion,
                    DNI = usuario.IdProfesorAdmisNavigation?.DNI.ToString(),
                    Categoria = usuario.IdProfesorAdmisNavigation?.IdCategoriaNavigation?.Descripcion
                });
            }
            return usuarioList;
        }

        // =====================
        // Reporte de usuarios con filtros
        // =====================
        public async Task<IEnumerable<UsuarioReporteDTO>> GetUsuariosReporte(UsuarioReporteFiltroDTO filtro)
        {
            return await _usuariosRepository.GetUsuariosReporteAsync(filtro);
        }
    }
}