using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    // Servicio de aplicación para la gestión de Categorias
    public class CategoriasService : ICategoriasService
    {
        // Repositorio de Categorias inyectado por dependencia
        private readonly ICategoriasRepository _repository;
        public CategoriasService(ICategoriasRepository repository)
        {
            _repository = repository;
        }

        // Obtiene todas las categorias y las mapea a DTOs de lista
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

        // Obtiene una categoria por su ID y la mapea a DTO de detalle
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

        // Crea una nueva categoria a partir de un DTO
        public async Task<int> CreateAsync(CategoriasCreateDTO dto)
        {
            var entity = new Categorias
            {
                Descripcion = dto.Descripcion,
                Estado = dto.Estado ?? 1 // Usa el estado proporcionado o 1 por defecto
            };
            return await _repository.CreateAsync(entity);
        }

        // Actualiza una categoria existente a partir de un DTO
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

        // Ya no elimina la categoria, solo retorna false
        public Task<bool> DeleteAsync(int id)
        {
            return Task.FromResult(false);
        }
    }
}
