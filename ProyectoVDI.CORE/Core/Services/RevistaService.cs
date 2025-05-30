using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaService : IRevistaService
    {
        private readonly IRevistaRepository _revistaRepository;

        public RevistaService(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }

        public async Task<IEnumerable<RevistaListDTO>> GetRevistas()
        {
            var revistas = await _revistaRepository.GetAllAsync();
            var list = new List<RevistaListDTO>();
            foreach (var revista in revistas)
            {
                list.Add(new RevistaListDTO
                {
                    IdRevista = revista.IdRevista,
                    Nombre = revista.Nombre,
                    Issn = revista.Issn
                });
            }
            return list;
        }

        public async Task<RevistaDTO?> GetRevistaById(int id)
        {
            var revista = await _revistaRepository.GetByIdAsync(id);
            if (revista == null) return null;
            return new RevistaDTO
            {
                IdRevista = revista.IdRevista,
                Issn = revista.Issn,
                Nombre = revista.Nombre,
                Country = revista.Country,
                Jif = revista.Jif,
                N = revista.N
            };
        }

        public async Task<int> CreateRevista(RevistaCreateDTO dto)
        {
            var revista = new Revista
            {
                Issn = dto.Issn,
                Nombre = dto.Nombre,
                Country = dto.Country,
                Jif = dto.Jif,
                N = dto.N
            };
            await _revistaRepository.CreateAsync(revista);
            return revista.IdRevista;
        }

        public async Task<bool> UpdateRevista(RevistaUpdateDTO dto)
        {
            var revista = await _revistaRepository.GetByIdAsync(dto.IdRevista);
            if (revista == null) return false;
            revista.Issn = dto.Issn;
            revista.Nombre = dto.Nombre;
            revista.Country = dto.Country;
            revista.Jif = dto.Jif;
            revista.N = dto.N;
            await _revistaRepository.UpdateAsync(revista);
            return true;
        }

        public async Task DeleteRevista(int id)
        {
            await _revistaRepository.DeleteAsync(id);
        }




        public async Task<IEnumerable<RevistaFullFlatDTO>> GetRevistasFullFlat()
        {
            var revistas = await _revistaRepository.GetRevistasWithAllJoinsAsync();
            var list = new List<RevistaFullFlatDTO>();
            foreach (var revista in revistas)
            {
                // Puedes hacer un foreach por cada relación si hay más de uno, o solo tomar el primero si es 1:1
                var evaluacion = revista.Evaluaciones.FirstOrDefault();
                var presencia = revista.PresenciaEnListas.FirstOrDefault();
                var editorial = revista.Editorial.FirstOrDefault();
                var autoria = revista.Autoria.FirstOrDefault();
                var indexacion = revista.RevistaIndexacion.FirstOrDefault();

                list.Add(new RevistaFullFlatDTO
                {
                    IdRevista = revista.IdRevista,
                    Issn = revista.Issn,
                    Nombre = revista.Nombre,
                    Country = revista.Country,
                    Jif = revista.Jif,
                    N = revista.N,

                    // Evaluaciones
                    IdEvaluacion = evaluacion?.IdEvaluacion ?? 0,
                    IdRevistaEvaluacion = evaluacion?.IdRevista,
                    Ajg4 = evaluacion?.Ajg4,
                    Ajg = evaluacion?.Ajg,
                    AjgS = evaluacion?.AjgS,
                    Cnrs = evaluacion?.Cnrs,
                    CnrsS = evaluacion?.CnrsS,
                    Abdc = evaluacion?.Abdc,
                    AbdcS = evaluacion?.AbdcS,
                    AjgExiste = evaluacion?.AjgExiste,
                    CnrsExiste = evaluacion?.CnrsExiste,
                    AbdcExiste = evaluacion?.AbdcExiste,

                    // PresenciaEnListas
                    IdRevistaPresencia = presencia?.IdRevista,
                    AlMenosEnUnaLista = presencia?.AlMenosEnUnaLista,
                    SoloEnUnaLista = presencia?.SoloEnUnaLista,
                    _216bEspecial = presencia?._216bEspecial,
                    Top50 = presencia?.Top50,
                    Multiple = presencia?.Múltiple,
                    MultyYAlMenosUnaLista = presencia?.MultyYAlMenosUnaLista,

                    // Editorial
                    IdRevistaEditorial = editorial?.IdRevista,
                    Mdpi = editorial?.Mdpi,
                    Insights = editorial?.Insights,
                    BeallSList = editorial?.BeallSList,

                    // Autoria
                    IdRevistaAutoria = autoria?.IdRevista,
                    CoautoriaEsan = autoria?.CoautoriaEsan,
                    PosicionDelAutor = autoria?.PosiciónDelAutor,

                    // RevistaIndexacion
                    IdRevistaIndexacion = indexacion?.IdRevista,
                    Scopus = indexacion?.Scopus,
                    WoSQ = indexacion?.WoSQ,
                    WoSS = indexacion?.WoSS ?? 0,
                    WoSEsci = indexacion?.WoSEsci,
                    EsciQ = indexacion?.EsciQ,
                    Scielo = indexacion?.Scielo,
                    WoSLatam = indexacion?.WoSLatam,
                    WoSTopExiste = indexacion?.WoSTopExiste,
                    WoSEsciExiste = indexacion?.WoSEsciExiste,
                    ScopusExiste = indexacion?.ScopusExiste,
                    SoloScieloExiste = indexacion?.SoloScieloExiste,
                    LatamSinEsciExiste = indexacion?.LatamSinEsciExiste,
                    EsciScieloSinScupus = indexacion?.EsciScieloSinScupus,
                    MultidisciplinaryWos = indexacion?.MultidisciplinaryWos,
                    MultidisciplinaryScopus = indexacion?.MultidisciplinaryScopus,
                    MultidisciplinaryWosOScopys = indexacion?.MultidisciplinaryWosOScopys
                });
            }
            return list;
        }
    }
}
