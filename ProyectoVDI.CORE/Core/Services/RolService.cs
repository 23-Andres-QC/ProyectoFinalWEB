using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;
        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RolListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<RolListDTO>();
            foreach (var item in list)
            {
                result.Add(new RolListDTO
                {
                    IdRol = item.IdRol,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<RolDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new RolDetailDTO
            {
                IdRol = item.IdRol,
                Descripcion = item.Descripcion,
                Estado = item.Estado
            };
        }

        public async Task<int> CreateAsync(RolCreateDTO dto)
        {
            var entity = new Rol
            {
                Descripcion = dto.Descripcion,
                Estado = 1
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(RolUpdateDTO dto)
        {
            var entity = new Rol
            {
                IdRol = dto.IdRol,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
