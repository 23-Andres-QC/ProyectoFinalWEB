using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaRegistroService : IRevistaRegistroService
    {
        private readonly IRevistaRepository _revistaRepo;
        private readonly IIssnsRevistaRepository _issnRepo;
        private readonly IMetadatosRevistaIssnRepository _metaRepo;
        private readonly IRegistroRevistasRepository _registroRepo;
        private readonly IDetRegistroRevistaRepository _detRepo;

        public RevistaRegistroService(
            IRevistaRepository revistaRepo,
            IIssnsRevistaRepository issnRepo,
            IMetadatosRevistaIssnRepository metaRepo,
            IRegistroRevistasRepository registroRepo,
            IDetRegistroRevistaRepository detRepo)
        {
            _revistaRepo = revistaRepo;
            _issnRepo = issnRepo;
            _metaRepo = metaRepo;
            _registroRepo = registroRepo;
            _detRepo = detRepo;
        }

        public async Task<IEnumerable<RevistaRegistroDTO>> GetAllRevistasAsync()
        {
            var revistas = await _revistaRepo.GetAllAsync();
            var issns = await _issnRepo.GetAllAsync();
            var metas = await _metaRepo.GetAllAsync();
            return revistas.Select(r => {
                var issnObj = issns.FirstOrDefault(i => i.IdRevista == r.IdRevista);
                var meta = metas.FirstOrDefault(m => m.IdRevista == r.IdRevista);
                return new RevistaRegistroDTO
                {
                    ISSN = issnObj?.Issn ?? string.Empty,
                    Nombre = r.Nombre ?? string.Empty,
                    Scopus = meta?.Scopus,
                    WoSQ = meta?.WoSQ,
                    WoSS = meta?.WoSS,
                    WoSEsci = meta?.WoSEsci,
                    EsciQ = meta?.EsciQ,
                    Ajg4star = meta?.Ajg4star,
                    Ajg = meta?.Ajg,
                    AjgS = meta?.AjgS,
                    Cnrs = meta?.Cnrs,
                    CnrsS = meta?.CnrsS,
                    Abdc = meta?.Abdc,
                    AbdcS = meta?.AbdcS,
                    AlMenosUnaLista = meta?.AlMenosUnaLista,
                    SoloUnaLista = meta?.SoloUnaLista,
                    Scielo = meta?.Scielo,
                    WoSLatam = meta?.WoSLatam,
                    Top50 = meta?.Top50,
                    N = meta?.N,
                    BeallsList = meta?.BeallsList,
                    Mdpi = meta?.Mdpi,
                    Insights = meta?.Insights,
                    AjgExiste = meta?.AjgExiste,
                    CnrsExiste = meta?.CnrsExiste,
                    AbdcExiste = meta?.AbdcExiste,
                    WoSTopExiste = meta?.WoSTopExiste,
                    WoSEsciExiste = meta?.WoSEsciExiste,
                    ScopusExiste = meta?.ScopusExiste,
                    SoloScieloExiste = meta?.SoloScieloExiste,
                    Especial216b = meta?.Especial216b,
                    LatamSinEsciExiste = meta?.LatamSinEsciExiste,
                    EsciScieloSinScopus = meta?.EsciScieloSinScopus,
                    Multiple = meta?.Multiple,
                    MultidisciplinaryWos = meta?.MultidisciplinaryWos,
                    CoautoriaEsan = meta?.CoautoriaEsan,
                    PosicionAutor = meta?.PosicionAutor,
                    Jif = meta?.Jif,
                    Country = meta?.Country,
                    MultyAlMenosUnaLista = meta?.MultyAlMenosUnaLista,
                    MultidisciplinaryScopus = meta?.MultidisciplinaryScopus,
                    MultidisciplinaryWosOScopys = meta?.MultidisciplinaryWosOScopys
                };
            });
        }

        public async Task<RevistaRegistroDTO?> GetRevistaByIssnAsync(string issn)
        {
            var issnObj = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == issn);
            if (issnObj == null || !issnObj.IdRevista.HasValue) return null;
            var revista = await _revistaRepo.GetByIdAsync(issnObj.IdRevista.Value);
            if (revista == null) return null;
            var meta = await _metaRepo.GetByIdAsync(revista.IdRevista);
            return new RevistaRegistroDTO
            {
                ISSN = issn,
                Nombre = revista.Nombre ?? string.Empty,
                Scopus = meta?.Scopus,
                WoSQ = meta?.WoSQ,
                WoSS = meta?.WoSS,
                WoSEsci = meta?.WoSEsci,
                EsciQ = meta?.EsciQ,
                Ajg4star = meta?.Ajg4star,
                Ajg = meta?.Ajg,
                AjgS = meta?.AjgS,
                Cnrs = meta?.Cnrs,
                CnrsS = meta?.CnrsS,
                Abdc = meta?.Abdc,
                AbdcS = meta?.AbdcS,
                AlMenosUnaLista = meta?.AlMenosUnaLista,
                SoloUnaLista = meta?.SoloUnaLista,
                Scielo = meta?.Scielo,
                WoSLatam = meta?.WoSLatam,
                Top50 = meta?.Top50,
                N = meta?.N,
                BeallsList = meta?.BeallsList,
                Mdpi = meta?.Mdpi,
                Insights = meta?.Insights,
                AjgExiste = meta?.AjgExiste,
                CnrsExiste = meta?.CnrsExiste,
                AbdcExiste = meta?.AbdcExiste,
                WoSTopExiste = meta?.WoSTopExiste,
                WoSEsciExiste = meta?.WoSEsciExiste,
                ScopusExiste = meta?.ScopusExiste,
                SoloScieloExiste = meta?.SoloScieloExiste,
                Especial216b = meta?.Especial216b,
                LatamSinEsciExiste = meta?.LatamSinEsciExiste,
                EsciScieloSinScopus = meta?.EsciScieloSinScopus,
                Multiple = meta?.Multiple,
                MultidisciplinaryWos = meta?.MultidisciplinaryWos,
                CoautoriaEsan = meta?.CoautoriaEsan,
                PosicionAutor = meta?.PosicionAutor,
                Jif = meta?.Jif,
                Country = meta?.Country,
                MultyAlMenosUnaLista = meta?.MultyAlMenosUnaLista,
                MultidisciplinaryScopus = meta?.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = meta?.MultidisciplinaryWosOScopys
            };
        }

        public async Task<IEnumerable<RevistaBasicaDTO>> GetCamposBasicosAsync()
        {
            var revistas = await _revistaRepo.GetAllAsync();
            var issns = await _issnRepo.GetAllAsync();
            return revistas.Select(r => new RevistaBasicaDTO
            {
                Nombre = r.Nombre ?? string.Empty,
                TipoLista = r.TipoLista ?? string.Empty,
                Issn = issns.FirstOrDefault(i => i.IdRevista == r.IdRevista)?.Issn ?? string.Empty
            });
        }

        public async Task<RevistaBasicaDTO?> GetCamposBasicosByIssnAsync(string issn)
        {
            var issnObj = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == issn);
            if (issnObj == null || !issnObj.IdRevista.HasValue) return null;
            var revista = await _revistaRepo.GetByIdAsync(issnObj.IdRevista.Value);
            if (revista == null) return null;
            return new RevistaBasicaDTO
            {
                Nombre = revista.Nombre ?? string.Empty,
                TipoLista = revista.TipoLista ?? string.Empty,
                Issn = issn
            };
        }

        public async Task<bool> RegistrarRevistasAsync(int idUsuario, string tipoRevista, List<RevistaRegistroDTO> revistas)
        {
            var registro = new RegistroRevistas
            {
                IdUsuario = idUsuario,
                FechaRegistro = DateTime.UtcNow
            };
            int idRegistro = await _registroRepo.CreateAsync(registro);
            foreach (var revistaDto in revistas)
            {
                var issnExistente = (await _issnRepo.GetAllAsync())
                    .FirstOrDefault(x => x.Issn == revistaDto.ISSN);
                int idRevista;
                if (issnExistente != null && issnExistente.IdRevista.HasValue)
                {
                    // Si el ISSN existe y tiene IdRevista, actualiza la revista
                    var revistaExistente = await _revistaRepo.GetByIdAsync(issnExistente.IdRevista.Value);
                    if (revistaExistente != null)
                    {
                        revistaExistente.Nombre = revistaDto.Nombre;
                        revistaExistente.TipoLista = tipoRevista;
                        revistaExistente.Estado = 1;
                        await _revistaRepo.UpdateAsync(revistaExistente);
                        idRevista = revistaExistente.IdRevista;
                    }
                    else
                    {
                        // Si el ISSN existe pero la revista no, crea la revista y asocia el ISSN
                        var nuevaRevista = new Revista
                        {
                            Nombre = revistaDto.Nombre,
                            TipoLista = tipoRevista,
                            Estado = 1
                        };
                        idRevista = await _revistaRepo.CreateAsync(nuevaRevista);
                        issnExistente.IdRevista = idRevista;
                        await _issnRepo.UpdateAsync(issnExistente);
                    }
                }
                else if (issnExistente == null)
                {
                    // Si el ISSN no existe, crea la revista y el ISSN
                    var nuevaRevista = new Revista
                    {
                        Nombre = revistaDto.Nombre,
                        TipoLista = tipoRevista,
                        Estado = 1
                    };
                    idRevista = await _revistaRepo.CreateAsync(nuevaRevista);
                    var nuevoIssn = new IssnsRevista
                    {
                        Issn = revistaDto.ISSN,
                        IdRevista = idRevista
                    };
                    await _issnRepo.CreateAsync(nuevoIssn);
                }
                else
                {
                    // Si el ISSN existe pero no tiene IdRevista, crea la revista y asocia el ISSN
                    var nuevaRevista = new Revista
                    {
                        Nombre = revistaDto.Nombre,
                        TipoLista = tipoRevista,
                        Estado = 1
                    };
                    idRevista = await _revistaRepo.CreateAsync(nuevaRevista);
                    issnExistente.IdRevista = idRevista;
                    await _issnRepo.UpdateAsync(issnExistente);
                }
                var metaExistente = await _metaRepo.GetByIdAsync(idRevista);
                var meta = new MetadatosRevistaIssn
                {
                    IdRevista = idRevista,
                    Scopus = revistaDto.Scopus,
                    WoSQ = revistaDto.WoSQ,
                    WoSS = revistaDto.WoSS,
                    WoSEsci = revistaDto.WoSEsci,
                    EsciQ = revistaDto.EsciQ,
                    Ajg4star = revistaDto.Ajg4star,
                    Ajg = revistaDto.Ajg,
                    AjgS = revistaDto.AjgS,
                    Cnrs = revistaDto.Cnrs,
                    CnrsS = revistaDto.CnrsS,
                    Abdc = revistaDto.Abdc,
                    AbdcS = revistaDto.AbdcS,
                    AlMenosUnaLista = revistaDto.AlMenosUnaLista,
                    SoloUnaLista = revistaDto.SoloUnaLista,
                    Scielo = revistaDto.Scielo,
                    WoSLatam = revistaDto.WoSLatam,
                    Top50 = revistaDto.Top50,
                    N = revistaDto.N,
                    BeallsList = revistaDto.BeallsList,
                    Mdpi = revistaDto.Mdpi,
                    Insights = revistaDto.Insights,
                    AjgExiste = revistaDto.AjgExiste,
                    CnrsExiste = revistaDto.CnrsExiste,
                    AbdcExiste = revistaDto.AbdcExiste,
                    WoSTopExiste = revistaDto.WoSTopExiste,
                    WoSEsciExiste = revistaDto.WoSEsciExiste,
                    ScopusExiste = revistaDto.ScopusExiste,
                    SoloScieloExiste = revistaDto.SoloScieloExiste,
                    Especial216b = revistaDto.Especial216b,
                    LatamSinEsciExiste = revistaDto.LatamSinEsciExiste,
                    EsciScieloSinScopus = revistaDto.EsciScieloSinScopus,
                    Multiple = revistaDto.Multiple,
                    MultidisciplinaryWos = revistaDto.MultidisciplinaryWos,
                    CoautoriaEsan = revistaDto.CoautoriaEsan,
                    PosicionAutor = revistaDto.PosicionAutor,
                    Jif = revistaDto.Jif,
                    Country = revistaDto.Country,
                    MultyAlMenosUnaLista = revistaDto.MultyAlMenosUnaLista,
                    MultidisciplinaryScopus = revistaDto.MultidisciplinaryScopus,
                    MultidisciplinaryWosOScopys = revistaDto.MultidisciplinaryWosOScopys
                };
                if (metaExistente != null)
                    await _metaRepo.UpdateAsync(meta);
                else
                    await _metaRepo.CreateAsync(meta);
                var det = new DetRegistroRevista
                {
                    IdRegistro = idRegistro,
                    IdRevista = idRevista
                };
                await _detRepo.CreateAsync(det);
            }
            return true;
        }

        public async Task<bool> ActualizarRevistaPorIssnAsync(RevistaRegistroDTO dto)
        {
            var issn = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == dto.ISSN);
            if (issn == null || !issn.IdRevista.HasValue) return false;
            var revista = await _revistaRepo.GetByIdAsync(issn.IdRevista.Value);
            if (revista == null) return false;
            revista.Nombre = dto.Nombre;
            await _revistaRepo.UpdateAsync(revista);
            var meta = new MetadatosRevistaIssn
            {
                IdRevista = revista.IdRevista,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSS = dto.WoSS,
                WoSEsci = dto.WoSEsci,
                EsciQ = dto.EsciQ,
                Ajg4star = dto.Ajg4star,
                Ajg = dto.Ajg,
                AjgS = dto.AjgS,
                Cnrs = dto.Cnrs,
                CnrsS = dto.CnrsS,
                Abdc = dto.Abdc,
                AbdcS = dto.AbdcS,
                AlMenosUnaLista = dto.AlMenosUnaLista,
                SoloUnaLista = dto.SoloUnaLista,
                Scielo = dto.Scielo,
                WoSLatam = dto.WoSLatam,
                Top50 = dto.Top50,
                N = dto.N,
                BeallsList = dto.BeallsList,
                Mdpi = dto.Mdpi,
                Insights = dto.Insights,
                AjgExiste = dto.AjgExiste,
                CnrsExiste = dto.CnrsExiste,
                AbdcExiste = dto.AbdcExiste,
                WoSTopExiste = dto.WoSTopExiste,
                WoSEsciExiste = dto.WoSEsciExiste,
                ScopusExiste = dto.ScopusExiste,
                SoloScieloExiste = dto.SoloScieloExiste,
                Especial216b = dto.Especial216b,
                LatamSinEsciExiste = dto.LatamSinEsciExiste,
                EsciScieloSinScopus = dto.EsciScieloSinScopus,
                Multiple = dto.Multiple,
                MultidisciplinaryWos = dto.MultidisciplinaryWos,
                CoautoriaEsan = dto.CoautoriaEsan,
                PosicionAutor = dto.PosicionAutor,
                Jif = dto.Jif,
                Country = dto.Country,
                MultyAlMenosUnaLista = dto.MultyAlMenosUnaLista,
                MultidisciplinaryScopus = dto.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys
            };
            var metaExistente = await _metaRepo.GetByIdAsync(revista.IdRevista);
            if (metaExistente != null)
                await _metaRepo.UpdateAsync(meta);
            else
                await _metaRepo.CreateAsync(meta);
            return true;
        }

        public async Task<bool> EliminarRevistaPorIssnAsync(string issn)
        {
            var issnObj = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == issn);
            if (issnObj == null || !issnObj.IdRevista.HasValue) return false;
            return await _revistaRepo.DeleteAsync(issnObj.IdRevista.Value);
        }

        // NUEVO: Obtener nombres de columnas válidas para consulta distinct en MetadatosRevistaISSN
        public Task<IEnumerable<string>> GetMetadatosColumnNamesAsync()
        {
            return _metaRepo.GetColumnNamesAsync();
        }

        // NUEVO: Obtener valores distintos de una columna en MetadatosRevistaISSN
        public Task<IEnumerable<string>> GetMetadatosDistinctValuesAsync(string columnName)
        {
            return _metaRepo.GetDistinctValuesAsync(columnName);
        }
    }
}
