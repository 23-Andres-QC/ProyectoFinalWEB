using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaListDTO>> GetCategorias()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var list = new List<CategoriaListDTO>();
            foreach (var categoria in categorias)
            {
                list.Add(new CategoriaListDTO
                {
                    IdCategoria = categoria.IdCategoria,
                    Descripcion = categoria.Descripcion
                });
            }
            return list;
        }

        public async Task<CategoriaDTO?> GetCategoriaById(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return null;
            return new CategoriaDTO
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
                Estado = categoria.Estado
            };
        }

        public async Task<int> CreateCategoria(CategoriaCreateDTO dto)
        {
            var categoria = new Categorias
            {
                Descripcion = dto.Descripcion,
                Estado = dto.Estado
            };
            return await _categoriaRepository.CreateAsync(categoria);
        }

        public async Task<bool> UpdateCategoria(CategoriaUpdateDTO dto)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(dto.IdCategoria);
            if (categoria == null) return false;
            categoria.Descripcion = dto.Descripcion;
            categoria.Estado = dto.Estado;
            await _categoriaRepository.UpdateAsync(categoria);
            return true;
        }

        public async Task DeleteCategoria(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }
    }
}
