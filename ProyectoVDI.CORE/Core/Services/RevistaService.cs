using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaService : IRevistaService
    {
        private readonly IRevistaRepository _repository;
        public RevistaService(IRevistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RevistaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<RevistaListDTO>();
            foreach (var item in list)
            {
                result.Add(new RevistaListDTO
                {
                    IdRevista = item.IdRevista,
                    Nombre = item.Nombre,
                    TipoLista = item.TipoLista,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<RevistaDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new RevistaDetailDTO
            {
                IdRevista = item.IdRevista,
                Nombre = item.Nombre,
                TipoLista = item.TipoLista,
                Estado = item.Estado
            };
        }

        public async Task<int> CreateAsync(RevistaCreateDTO dto)
        {
            var entity = new Revista
            {
                Nombre = dto.Nombre,
                TipoLista = dto.TipoLista,
                Estado = 1
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(RevistaUpdateDTO dto)
        {
            var entity = new Revista
            {
                IdRevista = dto.IdRevista,
                Nombre = dto.Nombre,
                TipoLista = dto.TipoLista,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> ChangeEstadoAsync(int id, int estado)
        {
            var revista = await _repository.GetByIdAsync(id);
            if (revista == null) return false;
            revista.Estado = estado;
            return await _repository.UpdateAsync(revista);
        }
    }
}
