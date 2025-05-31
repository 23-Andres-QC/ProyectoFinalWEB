using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class MetadatosRevistaIssnService : IMetadatosRevistaIssnService
    {
        private readonly IMetadatosRevistaIssnRepository _repository;
        public MetadatosRevistaIssnService(IMetadatosRevistaIssnRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MetadatosRevistaIssnListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<MetadatosRevistaIssnListDTO>();
            foreach (var item in list)
            {
                result.Add(new MetadatosRevistaIssnListDTO
                {
                    IdRevista = item.IdRevista,
                    Scopus = item.Scopus,
                    WoSQ = item.WoSQ,
                    WoSEsci = item.WoSEsci,
                    Ajg = item.Ajg,
                    Cnrs = item.Cnrs,
                    Abdc = item.Abdc
                });
            }
            return result;
        }

        public async Task<MetadatosRevistaIssnDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new MetadatosRevistaIssnDetailDTO
            {
                IdRevista = item.IdRevista,
                Scopus = item.Scopus,
                WoSQ = item.WoSQ,
                WoSS = item.WoSS?.ToString(),
                WoSEsci = item.WoSEsci,
                EsciQ = item.EsciQ,
                Ajg4star = item.Ajg4star,
                Ajg = item.Ajg,
                Cnrs = item.Cnrs,
                Abdc = item.Abdc,
                AlMenosUnaLista = item.AlMenosUnaLista,
                SoloUnaLista = item.SoloUnaLista,
                Scielo = item.Scielo,
                WoSLatam = item.WoSLatam,
                Top50 = item.Top50,
                BeallsList = item.BeallsList,
                Mdpi = item.Mdpi,
                Insights = item.Insights,
                CoautoriaEsan = item.CoautoriaEsan,
                PosicionAutor = item.PosicionAutor,
                Jif = item.Jif,
                Country = item.Country
            };
        }

        public async Task<int> CreateAsync(MetadatosRevistaIssnCreateDTO dto)
        {
            var entity = new MetadatosRevistaIssn
            {
                IdRevista = dto.IdRevista,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSEsci = dto.WoSEsci,
                Ajg = dto.Ajg,
                Cnrs = dto.Cnrs,
                Abdc = dto.Abdc
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(MetadatosRevistaIssnUpdateDTO dto)
        {
            var entity = new MetadatosRevistaIssn
            {
                IdRevista = dto.IdRevista,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSEsci = dto.WoSEsci,
                Ajg = dto.Ajg,
                Cnrs = dto.Cnrs,
                Abdc = dto.Abdc
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
