using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RegistroRevistasService : IRegistroRevistasService
    {
        private readonly IRegistroRevistasRepository _repository;
        public RegistroRevistasService(IRegistroRevistasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RegistroRevistasListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<RegistroRevistasListDTO>();
            foreach (var item in list)
            {
                result.Add(new RegistroRevistasListDTO
                {
                    IdRegistro = item.IdRegistro,
                    IdUsuario = item.IdUsuario,
                    FechaRegistro = item.FechaRegistro
                });
            }
            return result;
        }

        public async Task<RegistroRevistasDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new RegistroRevistasDetailDTO
            {
                IdRegistro = item.IdRegistro,
                IdUsuario = item.IdUsuario,
                FechaRegistro = item.FechaRegistro
            };
        }

        public async Task<int> CreateAsync(RegistroRevistasCreateDTO dto)
        {
            var entity = new RegistroRevistas
            {
                IdUsuario = dto.IdUsuario
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(RegistroRevistasUpdateDTO dto)
        {
            var entity = new RegistroRevistas
            {
                IdRegistro = dto.IdRegistro,
                IdUsuario = dto.IdUsuario
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
