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

        public async Task<IEnumerable<RevistaListDTO>> GetRevistas()
        {
            var revistas = await _repository.GetAllAsync();
            var list = new List<RevistaListDTO>();
            foreach (var r in revistas)
            {
                list.Add(new RevistaListDTO
                {
                    IdRevista = r.IdRevista,
                    Nombre = r.Nombre,
                    Issn = r.Issn
                });
            }
            return list;
        }

        public async Task<RevistaDTO?> GetRevistaById(int id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;
            return new RevistaDTO
            {
                IdRevista = r.IdRevista,
                Issn = r.Issn,
                Nombre = r.Nombre,
                Scopus = r.Scopus,
                WoSQ = r.WoSQ,
                WoSS = r.WoSS,
                WoSEsci = r.WoSEsci,
                EsciQ = r.EsciQ,
                Ajg4 = r.Ajg4,
                Ajg = r.Ajg,
                AjgS = r.AjgS,
                Cnrs = r.Cnrs,
                CnrsS = r.CnrsS,
                Abdc = r.Abdc,
                AbdcS = r.AbdcS,
                AlMenosEnUnaLista = r.AlMenosEnUnaLista,
                SoloEnUnaLista = r.SoloEnUnaLista,
                Scielo = r.Scielo,
                WoSLatam = r.WoSLatam,
                Top50 = r.Top50,
                N = r.N,
                BeallSList = r.BeallSList,
                Mdpi = r.Mdpi,
                Insights = r.Insights,
                AjgExiste = r.AjgExiste,
                CnrsExiste = r.CnrsExiste,
                AbdcExiste = r.AbdcExiste,
                WoSTopExiste = r.WoSTopExiste,
                WoSEsciExiste = r.WoSEsciExiste,
                ScopusExiste = r.ScopusExiste,
                SoloScieloExiste = r.SoloScieloExiste,
                _216bEspecial = r._216bEspecial,
                LatamSinEsciExiste = r.LatamSinEsciExiste,
                EsciScieloSinScupus = r.EsciScieloSinScupus,
                Múltiple = r.Múltiple,
                MultidisciplinaryWos = r.MultidisciplinaryWos,
                CoautoriaEsan = r.CoautoriaEsan,
                PosiciónDelAutor = r.PosiciónDelAutor,
                Jif = r.Jif,
                Country = r.Country,
                MultyYAlMenosUnaLista = r.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = r.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = r.MultidisciplinaryWosOScopys,
                Estado = r.Estado
            };
        }

        public async Task<int> CreateRevista(RevistaCreateDTO dto)
        {
            var r = new Revista
            {
                Issn = dto.Issn,
                Nombre = dto.Nombre
                // Agrega aquí los campos requeridos para crear
            };
            await _repository.CreateAsync(r);
            return r.IdRevista;
        }

        public async Task<bool> UpdateRevista(RevistaUpdateDTO dto)
        {
            var r = await _repository.GetByIdAsync(dto.IdRevista);
            if (r == null) return false;
            r.Issn = dto.Issn;
            r.Nombre = dto.Nombre;
            // Agrega aquí los campos requeridos para actualizar
            await _repository.UpdateAsync(r);
            return true;
        }

        public async Task DeleteRevista(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}