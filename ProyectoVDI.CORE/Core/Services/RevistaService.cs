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
            return revistas.Select(r => new RevistaListDTO
            {
                IdRevista = r.IdRevista,
                Nombre = r.Nombre,
                Issn = r.Issn
            });
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
            };
            await _repository.CreateAsync(r);
            return r.IdRevista;
        }

        public async Task<bool> UpdateRevista(RevistaUpdateDTO dto)
        {
            var r = await _repository.GetByIdAsync(dto.IdRevista);
            if (r == null) return false;
            if (dto.Nombre != null) r.Nombre = dto.Nombre;
            if (dto.Scopus != null) r.Scopus = dto.Scopus;
            if (dto.WoSQ != null) r.WoSQ = dto.WoSQ;
            if (dto.WoSS.HasValue) r.WoSS = dto.WoSS;
            if (dto.WoSEsci != null) r.WoSEsci = dto.WoSEsci;
            if (dto.EsciQ != null) r.EsciQ = dto.EsciQ;
            if (dto.Ajg4 != null) r.Ajg4 = dto.Ajg4;
            if (dto.Ajg != null) r.Ajg = dto.Ajg;
            if (dto.AjgS.HasValue) r.AjgS = dto.AjgS;
            if (dto.Cnrs != null) r.Cnrs = dto.Cnrs;
            if (dto.CnrsS.HasValue) r.CnrsS = dto.CnrsS;
            if (dto.Abdc != null) r.Abdc = dto.Abdc;
            if (dto.AbdcS.HasValue) r.AbdcS = dto.AbdcS;
            if (dto.AlMenosEnUnaLista != null) r.AlMenosEnUnaLista = dto.AlMenosEnUnaLista;
            if (dto.SoloEnUnaLista != null) r.SoloEnUnaLista = dto.SoloEnUnaLista;
            if (dto.Scielo != null) r.Scielo = dto.Scielo;
            if (dto.WoSLatam != null) r.WoSLatam = dto.WoSLatam;
            if (dto.Top50 != null) r.Top50 = dto.Top50;
            if (dto.N.HasValue) r.N = dto.N;
            if (dto.BeallSList != null) r.BeallSList = dto.BeallSList;
            if (dto.Mdpi != null) r.Mdpi = dto.Mdpi;
            if (dto.Insights != null) r.Insights = dto.Insights;
            if (dto.AjgExiste.HasValue) r.AjgExiste = dto.AjgExiste;
            if (dto.CnrsExiste.HasValue) r.CnrsExiste = dto.CnrsExiste;
            if (dto.AbdcExiste.HasValue) r.AbdcExiste = dto.AbdcExiste;
            if (dto.WoSTopExiste.HasValue) r.WoSTopExiste = dto.WoSTopExiste;
            if (dto.WoSEsciExiste.HasValue) r.WoSEsciExiste = dto.WoSEsciExiste;
            if (dto.ScopusExiste.HasValue) r.ScopusExiste = dto.ScopusExiste;
            if (dto.SoloScieloExiste.HasValue) r.SoloScieloExiste = dto.SoloScieloExiste;
            if (dto._216bEspecial.HasValue) r._216bEspecial = dto._216bEspecial;
            if (dto.LatamSinEsciExiste.HasValue) r.LatamSinEsciExiste = dto.LatamSinEsciExiste;
            if (dto.EsciScieloSinScupus.HasValue) r.EsciScieloSinScupus = dto.EsciScieloSinScupus;
            if (dto.Múltiple.HasValue) r.Múltiple = dto.Múltiple;
            if (dto.MultidisciplinaryWos.HasValue) r.MultidisciplinaryWos = dto.MultidisciplinaryWos;
            if (dto.CoautoriaEsan != null) r.CoautoriaEsan = dto.CoautoriaEsan;
            if (dto.PosiciónDelAutor != null) r.PosiciónDelAutor = dto.PosiciónDelAutor;
            if (dto.Jif.HasValue) r.Jif = dto.Jif;
            if (dto.Country != null) r.Country = dto.Country;
            if (dto.MultyYAlMenosUnaLista.HasValue) r.MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista;
            if (dto.MultidisciplinaryScopus.HasValue) r.MultidisciplinaryScopus = dto.MultidisciplinaryScopus;
            if (dto.MultidisciplinaryWosOScopys.HasValue) r.MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys;
            if (dto.Estado.HasValue) r.Estado = dto.Estado;
            await _repository.UpdateAsync(r);
            return true;
        }

        public async Task DeleteRevista(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}