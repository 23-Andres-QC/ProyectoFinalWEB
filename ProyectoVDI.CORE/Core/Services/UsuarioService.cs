using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<UsuarioListDTO>();
            foreach (var item in list)
            {
                result.Add(new UsuarioListDTO
                {
                    IdUsuario = item.IdUsuario,
                    IdProfesorAdmis = item.IdProfesorAdmis,
                    Correo = item.Correo,
                    IdRol = item.IdRol,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<UsuarioDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new UsuarioDetailDTO
            {
                IdUsuario = item.IdUsuario,
                IdProfesorAdmis = item.IdProfesorAdmis,
                Correo = item.Correo,
                Contraseña = item.Contraseña,
                IdRol = item.IdRol,
                Estado = item.Estado,
                FechaCreacion = item.FechaCreacion,
                FechaModificacion = item.FechaModificacion
            };
        }

        public async Task<int> CreateAsync(UsuarioCreateDTO dto)
        {
            var entity = new Usuario
            {
                IdProfesorAdmis = dto.IdProfesorAdmis,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                IdRol = dto.IdRol,
                Estado = 1,
                FechaCreacion = System.DateTime.Now
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(UsuarioUpdateDTO dto)
        {
            var entity = new Usuario
            {
                IdUsuario = dto.IdUsuario,
                IdProfesorAdmis = dto.IdProfesorAdmis,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                IdRol = dto.IdRol,
                Estado = dto.Estado,
                FechaModificacion = System.DateTime.Now
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
