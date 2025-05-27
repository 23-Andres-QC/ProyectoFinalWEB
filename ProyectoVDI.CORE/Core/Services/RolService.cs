using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RolService 
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<RolListDTO>> GetRoles()
        {
            var roles = await _rolRepository.GetAllAsync();
            var list = new List<RolListDTO>();
            foreach (var rol in roles)
            {
                list.Add(new RolListDTO
                {
                    IdRol = rol.IdRol,
                    Descripcion = rol.Descripcion
                });
            }
            return list;
        }

        public async Task<RolDTO?> GetRolById(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null) return null;
            return new RolDTO
            {
                IdRol = rol.IdRol,
                Descripcion = rol.Descripcion
            };
        }

        public async Task<int> CreateRol(RolCreateDTO dto)
        {
            var rol = new Rol
            {
                Descripcion = dto.Descripcion
            };
            return await _rolRepository.CreateAsync(rol);
        }

        public async Task<bool> UpdateRol(RolUpdateDTO dto)
        {
            var rol = await _rolRepository.GetByIdAsync(dto.IdRol);
            if (rol == null) return false;
            rol.Descripcion = dto.Descripcion;
            await _rolRepository.UpdateAsync(rol);
            return true;
        }

        public async Task DeleteRol(int id)
        {
            await _rolRepository.DeleteAsync(id);
        }
    }
}
