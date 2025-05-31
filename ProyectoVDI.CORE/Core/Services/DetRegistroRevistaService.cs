using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class DetRegistroRevistaService : IDetRegistroRevistaService
    {
        private readonly IDetRegistroRevistaRepository _repository;
        public DetRegistroRevistaService(IDetRegistroRevistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DetRegistroRevistaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<DetRegistroRevistaListDTO>();
            foreach (var item in list)
            {
                result.Add(new DetRegistroRevistaListDTO
                {
                    IdDetalle = item.IdDetalle,
                    IdRegistro = item.IdRegistro,
                    IdRevista = item.IdRevista
                });
            }
            return result;
        }

        public async Task<DetRegistroRevistaDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new DetRegistroRevistaDetailDTO
            {
                IdDetalle = item.IdDetalle,
                IdRegistro = item.IdRegistro,
                IdRevista = item.IdRevista
            };
        }

        public async Task<int> CreateAsync(DetRegistroRevistaCreateDTO dto)
        {
            var entity = new DetRegistroRevista
            {
                IdRegistro = dto.IdRegistro,
                IdRevista = dto.IdRevista
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(DetRegistroRevistaUpdateDTO dto)
        {
            var entity = new DetRegistroRevista
            {
                IdDetalle = dto.IdDetalle,
                IdRegistro = dto.IdRegistro,
                IdRevista = dto.IdRevista
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
