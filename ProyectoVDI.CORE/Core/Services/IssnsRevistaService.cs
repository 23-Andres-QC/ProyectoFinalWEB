using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class IssnsRevistaService : IIssnsRevistaService
    {
        private readonly IIssnsRevistaRepository _repository;
        public IssnsRevistaService(IIssnsRevistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IssnsRevistaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<IssnsRevistaListDTO>();
            foreach (var item in list)
            {
                result.Add(new IssnsRevistaListDTO
                {
                    IdIssn = item.IdIssn,
                    IdRevista = item.IdRevista,
                    Issn = item.Issn
                });
            }
            return result;
        }

        public async Task<IssnsRevistaDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new IssnsRevistaDetailDTO
            {
                IdIssn = item.IdIssn,
                IdRevista = item.IdRevista,
                Issn = item.Issn
            };
        }

        public async Task<int> CreateAsync(IssnsRevistaCreateDTO dto)
        {
            var entity = new IssnsRevista
            {
                IdRevista = dto.IdRevista,
                Issn = dto.Issn
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(IssnsRevistaUpdateDTO dto)
        {
            var entity = new IssnsRevista
            {
                IdIssn = dto.IdIssn,
                IdRevista = dto.IdRevista,
                Issn = dto.Issn
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
