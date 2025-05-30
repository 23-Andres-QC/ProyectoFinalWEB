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
                Nombre = dto.Nombre,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSS = dto.WoSS,
                WoSEsci = dto.WoSEsci,
                EsciQ = dto.EsciQ,
                Ajg4 = dto.Ajg4,
                Ajg = dto.Ajg,
                AjgS = dto.AjgS,
                Cnrs = dto.Cnrs,
                CnrsS = dto.CnrsS,
                Abdc = dto.Abdc,
                AbdcS = dto.AbdcS,
                AlMenosEnUnaLista = dto.AlMenosEnUnaLista,
                SoloEnUnaLista = dto.SoloEnUnaLista,
                Scielo = dto.Scielo,
                WoSLatam = dto.WoSLatam,
                Top50 = dto.Top50,
                N = dto.N,
                BeallSList = dto.BeallSList,
                Mdpi = dto.Mdpi,
                Insights = dto.Insights,
                AjgExiste = dto.AjgExiste,
                CnrsExiste = dto.CnrsExiste,
                AbdcExiste = dto.AbdcExiste,
                WoSTopExiste = dto.WoSTopExiste,
                WoSEsciExiste = dto.WoSEsciExiste,
                ScopusExiste = dto.ScopusExiste,
                SoloScieloExiste = dto.SoloScieloExiste,
                _216bEspecial = dto._216bEspecial,
                LatamSinEsciExiste = dto.LatamSinEsciExiste,
                EsciScieloSinScupus = dto.EsciScieloSinScupus,
                Múltiple = dto.Múltiple,
                MultidisciplinaryWos = dto.MultidisciplinaryWos,
                CoautoriaEsan = dto.CoautoriaEsan,
                PosiciónDelAutor = dto.PosiciónDelAutor,
                Jif = dto.Jif,
                Country = dto.Country,
                MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = dto.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys,
                Estado = dto.Estado
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
            r.Scopus = dto.Scopus;
            r.WoSQ = dto.WoSQ;
            r.WoSS = dto.WoSS;
            r.WoSEsci = dto.WoSEsci;
            r.EsciQ = dto.EsciQ;
            r.Ajg4 = dto.Ajg4;
            r.Ajg = dto.Ajg;
            r.AjgS = dto.AjgS;
            r.Cnrs = dto.Cnrs;
            r.CnrsS = dto.CnrsS;
            r.Abdc = dto.Abdc;
            r.AbdcS = dto.AbdcS;
            r.AlMenosEnUnaLista = dto.AlMenosEnUnaLista;
            r.SoloEnUnaLista = dto.SoloEnUnaLista;
            r.Scielo = dto.Scielo;
            r.WoSLatam = dto.WoSLatam;
            r.Top50 = dto.Top50;
            r.N = dto.N;
            r.BeallSList = dto.BeallSList;
            r.Mdpi = dto.Mdpi;
            r.Insights = dto.Insights;
            r.AjgExiste = dto.AjgExiste;
            r.CnrsExiste = dto.CnrsExiste;
            r.AbdcExiste = dto.AbdcExiste;
            r.WoSTopExiste = dto.WoSTopExiste;
            r.WoSEsciExiste = dto.WoSEsciExiste;
            r.ScopusExiste = dto.ScopusExiste;
            r.SoloScieloExiste = dto.SoloScieloExiste;
            r._216bEspecial = dto._216bEspecial;
            r.LatamSinEsciExiste = dto.LatamSinEsciExiste;
            r.EsciScieloSinScupus = dto.EsciScieloSinScupus;
            r.Múltiple = dto.Múltiple;
            r.MultidisciplinaryWos = dto.MultidisciplinaryWos;
            r.CoautoriaEsan = dto.CoautoriaEsan;
            r.PosiciónDelAutor = dto.PosiciónDelAutor;
            r.Jif = dto.Jif;
            r.Country = dto.Country;
            r.MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista;
            r.MultidisciplinaryScopus = dto.MultidisciplinaryScopus;
            r.MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys;
            r.Estado = dto.Estado;
            await _repository.UpdateAsync(r);
            return true;
        }

        public async Task DeleteRevista(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}