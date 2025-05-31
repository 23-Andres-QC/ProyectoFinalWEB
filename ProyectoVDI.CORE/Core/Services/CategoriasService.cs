using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository _repository;
        public CategoriasService(ICategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoriasListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<CategoriasListDTO>();
            foreach (var item in list)
            {
                result.Add(new CategoriasListDTO
                {
                    IdCategoria = item.IdCategoria,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<CategoriasDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new CategoriasDetailDTO
            {
                IdCategoria = item.IdCategoria,
                Descripcion = item.Descripcion,
                Estado = item.Estado
            };
        }

        public async Task<int> CreateAsync(CategoriasCreateDTO dto)
        {
            var entity = new Categorias
            {
                Descripcion = dto.Descripcion,
                Estado = 1
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(CategoriasUpdateDTO dto)
        {
            var entity = new Categorias
            {
                IdCategoria = dto.IdCategoria,
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
