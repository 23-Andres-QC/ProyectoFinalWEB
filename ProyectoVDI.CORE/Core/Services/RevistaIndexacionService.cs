using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaIndexacionService 
    {
        private readonly IRevistasIndexacionRepository _repository;

        public RevistaIndexacionService(IRevistasIndexacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RevistaIndexacionListDTO>> GetRevistaIndexaciones()
        {
            var indexaciones = await _repository.GetAllAsync();
            var list = new List<RevistaIndexacionListDTO>();
            foreach (var idx in indexaciones)
            {
                list.Add(new RevistaIndexacionListDTO
                {
                    IdIndexacion = idx.IdIndexacion,
                    IdRevista = idx.IdRevista
                });
            }
            return list;
        }

        public async Task<RevistaIndexacionDTO?> GetRevistaIndexacionById(int id)
        {
            var idx = await _repository.GetByIdAsync(id);
            if (idx == null) return null;
            return new RevistaIndexacionDTO
            {
                IdIndexacion = idx.IdIndexacion,
                IdRevista = idx.IdRevista,
                Scopus = idx.Scopus,
                WoSQ = idx.WoSQ,
                WoSS = idx.WoSS,
                WoSEsci = idx.WoSEsci,
                EsciQ = idx.EsciQ,
                Scielo = idx.Scielo,
                WoSLatam = idx.WoSLatam,
                WoSTopExiste = idx.WoSTopExiste,
                WoSEsciExiste = idx.WoSEsciExiste,
                ScopusExiste = idx.ScopusExiste,
                SoloScieloExiste = idx.SoloScieloExiste,
                LatamSinEsciExiste = idx.LatamSinEsciExiste,
                EsciScieloSinScupus = idx.EsciScieloSinScupus,
                MultidisciplinaryWos = idx.MultidisciplinaryWos,
                MultidisciplinaryScopus = idx.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = idx.MultidisciplinaryWosOScopys
            };
        }

        public async Task<int> CreateRevistaIndexacion(RevistaIndexacionCreateDTO dto)
        {
            var idx = new RevistaIndexacion
            {
                IdRevista = dto.IdRevista,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSS = dto.WoSS,
                WoSEsci = dto.WoSEsci,
                EsciQ = dto.EsciQ,
                Scielo = dto.Scielo,
                WoSLatam = dto.WoSLatam,
                WoSTopExiste = dto.WoSTopExiste,
                WoSEsciExiste = dto.WoSEsciExiste,
                ScopusExiste = dto.ScopusExiste,
                SoloScieloExiste = dto.SoloScieloExiste,
                LatamSinEsciExiste = dto.LatamSinEsciExiste,
                EsciScieloSinScupus = dto.EsciScieloSinScupus,
                MultidisciplinaryWos = dto.MultidisciplinaryWos,
                MultidisciplinaryScopus = dto.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys
            };
            return await _repository.CreateAsync(idx);
        }

        public async Task<bool> UpdateRevistaIndexacion(RevistaIndexacionUpdateDTO dto)
        {
            var idx = await _repository.GetByIdAsync(dto.IdIndexacion);
            if (idx == null) return false;
            idx.IdRevista = dto.IdRevista;
            idx.Scopus = dto.Scopus;
            idx.WoSQ = dto.WoSQ;
            idx.WoSS = dto.WoSS;
            idx.WoSEsci = dto.WoSEsci;
            idx.EsciQ = dto.EsciQ;
            idx.Scielo = dto.Scielo;
            idx.WoSLatam = dto.WoSLatam;
            idx.WoSTopExiste = dto.WoSTopExiste;
            idx.WoSEsciExiste = dto.WoSEsciExiste;
            idx.ScopusExiste = dto.ScopusExiste;
            idx.SoloScieloExiste = dto.SoloScieloExiste;
            idx.LatamSinEsciExiste = dto.LatamSinEsciExiste;
            idx.EsciScieloSinScupus = dto.EsciScieloSinScupus;
            idx.MultidisciplinaryWos = dto.MultidisciplinaryWos;
            idx.MultidisciplinaryScopus = dto.MultidisciplinaryScopus;
            idx.MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys;
            await _repository.UpdateAsync(idx);
            return true;
        }

        public async Task DeleteRevistaIndexacion(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
