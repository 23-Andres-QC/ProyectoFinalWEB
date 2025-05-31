using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaListaCerradaService : IRevistaListaCerradaService
    {
        private readonly IRevistaListaCerradaRepository _repository;
        public RevistaListaCerradaService(IRevistaListaCerradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RevistaListaCerradaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<RevistaListaCerradaListDTO>();
            foreach (var item in list)
            {
                result.Add(new RevistaListaCerradaListDTO
                {
                    IdRevista = item.IdRevista,
                    Nombre = item.Nombre,
                    Categoria = item.Categoria,
                    Puntaje = item.Puntaje,
                    IncentivoUsd = item.IncentivoUsd
                });
            }
            return result;
        }

        public async Task<RevistaListaCerradaDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new RevistaListaCerradaDetailDTO
            {
                IdRevista = item.IdRevista,
                Nombre = item.Nombre,
                Categoria = item.Categoria,
                Puntaje = item.Puntaje,
                IncentivoUsd = item.IncentivoUsd,
                Scopus = item.Scopus,
                WoSQ = item.WoSQ,
                EsciQ = item.EsciQ,
                Ajg = item.Ajg,
                Cnrs = item.Cnrs,
                Abdc = item.Abdc,
                WoSLatam = item.WoSLatam
            };
        }

        public async Task<int> CreateAsync(RevistaListaCerradaCreateDTO dto)
        {
            var entity = new RevistaListaCerrada
            {
                IdRevista = dto.IdRevista,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Puntaje = dto.Puntaje,
                IncentivoUsd = dto.IncentivoUsd
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(RevistaListaCerradaUpdateDTO dto)
        {
            var entity = new RevistaListaCerrada
            {
                IdRevista = dto.IdRevista,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Puntaje = dto.Puntaje,
                IncentivoUsd = dto.IncentivoUsd
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
