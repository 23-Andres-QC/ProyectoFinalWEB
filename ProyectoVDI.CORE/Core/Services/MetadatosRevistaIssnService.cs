using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoVDI.CORE.Core.Services
{
    // Servicio de aplicación para la gestión de MetadatosRevistaIssn
    public class MetadatosRevistaIssnService : IMetadatosRevistaIssnService
    {
        // Repositorio de MetadatosRevistaIssn inyectado por dependencia
        private readonly IMetadatosRevistaIssnRepository _repository;
        private readonly vdiContext _context;
        public MetadatosRevistaIssnService(IMetadatosRevistaIssnRepository repository, vdiContext context)
        {
            _repository = repository;
            _context = context;
        }

        // Obtiene todos los registros para visualización en tabla, incluyendo el nombre de la revista
        public async Task<IEnumerable<MetadatosRevistaIssnListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var revistas = await _context.Revista.ToDictionaryAsync(r => r.IdRevista, r => r.Nombre);
            var issns = await _context.IssnsRevista.GroupBy(i => i.IdRevista).ToDictionaryAsync(g => g.Key, g => g.Select(x => x.Issn).FirstOrDefault());
            var result = new List<MetadatosRevistaIssnListDTO>();
            foreach (var item in list)
            {
                revistas.TryGetValue(item.IdRevista, out var nombreRevista);
                issns.TryGetValue(item.IdRevista, out var issn);
                result.Add(new MetadatosRevistaIssnListDTO
                {
                    IdRevista = item.IdRevista,
                    NombreRevista = nombreRevista,
                    Issn = issn,
                    Scopus = item.Scopus,
                    WoSQ = item.WoSQ,
                    WoSS = item.WoSS,
                    WoSEsci = item.WoSEsci,
                    EsciQ = item.EsciQ,
                    Ajg4star = item.Ajg4star,
                    Ajg = item.Ajg,
                    AjgS = item.AjgS,
                    Cnrs = item.Cnrs,
                    CnrsS = item.CnrsS,
                    Abdc = item.Abdc,
                    AbdcS = item.AbdcS,
                    AlMenosUnaLista = item.AlMenosUnaLista,
                    SoloUnaLista = item.SoloUnaLista,
                    Scielo = item.Scielo,
                    WoSLatam = item.WoSLatam,
                    Top50 = item.Top50,
                    N = item.N,
                    BeallsList = item.BeallsList,
                    Mdpi = item.Mdpi,
                    Insights = item.Insights,
                    AjgExiste = item.AjgExiste,
                    CnrsExiste = item.CnrsExiste,
                    AbdcExiste = item.AbdcExiste,
                    WoSTopExiste = item.WoSTopExiste,
                    WoSEsciExiste = item.WoSEsciExiste,
                    ScopusExiste = item.ScopusExiste,
                    SoloScieloExiste = item.SoloScieloExiste,
                    Especial216b = item.Especial216b,
                    LatamSinEsciExiste = item.LatamSinEsciExiste,
                    EsciScieloSinScopus = item.EsciScieloSinScopus,
                    Multiple = item.Multiple,
                    MultidisciplinaryWos = item.MultidisciplinaryWos,
                    CoautoriaEsan = item.CoautoriaEsan,
                    PosicionAutor = item.PosicionAutor,
                    Jif = item.Jif,
                    Country = item.Country,
                    MultyAlMenosUnaLista = item.MultyAlMenosUnaLista,
                    MultidisciplinaryScopus = item.MultidisciplinaryScopus,
                    MultidisciplinaryWosOScopys = item.MultidisciplinaryWosOScopys
                });
            }
            return result;
        }

        // Obtiene el detalle de un registro por su ID, incluyendo el nombre de la revista
        public async Task<MetadatosRevistaIssnDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            var nombreRevista = await _context.Revista.Where(r => r.IdRevista == id).Select(r => r.Nombre).FirstOrDefaultAsync();
            var issn = await _context.IssnsRevista.Where(i => i.IdRevista == id).Select(i => i.Issn).FirstOrDefaultAsync();
            return new MetadatosRevistaIssnDetailDTO
            {
                IdRevista = item.IdRevista,
                NombreRevista = nombreRevista,
                Issn = issn,
                Scopus = item.Scopus,
                WoSQ = item.WoSQ,
                WoSS = item.WoSS,
                WoSEsci = item.WoSEsci,
                EsciQ = item.EsciQ,
                Ajg4star = item.Ajg4star,
                Ajg = item.Ajg,
                AjgS = item.AjgS,
                Cnrs = item.Cnrs,
                CnrsS = item.CnrsS,
                Abdc = item.Abdc,
                AbdcS = item.AbdcS,
                AlMenosUnaLista = item.AlMenosUnaLista,
                SoloUnaLista = item.SoloUnaLista,
                Scielo = item.Scielo,
                WoSLatam = item.WoSLatam,
                Top50 = item.Top50,
                N = item.N,
                BeallsList = item.BeallsList,
                Mdpi = item.Mdpi,
                Insights = item.Insights,
                AjgExiste = item.AjgExiste,
                CnrsExiste = item.CnrsExiste,
                AbdcExiste = item.AbdcExiste,
                WoSTopExiste = item.WoSTopExiste,
                WoSEsciExiste = item.WoSEsciExiste,
                ScopusExiste = item.ScopusExiste,
                SoloScieloExiste = item.SoloScieloExiste,
                Especial216b = item.Especial216b,
                LatamSinEsciExiste = item.LatamSinEsciExiste,
                EsciScieloSinScopus = item.EsciScieloSinScopus,
                Multiple = item.Multiple,
                MultidisciplinaryWos = item.MultidisciplinaryWos,
                CoautoriaEsan = item.CoautoriaEsan,
                PosicionAutor = item.PosicionAutor,
                Jif = item.Jif,
                Country = item.Country,
                MultyAlMenosUnaLista = item.MultyAlMenosUnaLista,
                MultidisciplinaryScopus = item.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopys = item.MultidisciplinaryWosOScopys
            };
        }

        // Crea un nuevo registro de MetadatosRevistaIssn y actualiza/crea el nombre en la entidad Revista
        public async Task<int> CreateAsync(MetadatosRevistaIssnCreateDTO dto)
        {
            // Actualiza o crea el nombre en la entidad Revista
            var revista = await _context.Revista.FindAsync(dto.IdRevista);
            if (revista == null)
            {
                revista = new Revista { IdRevista = dto.IdRevista, Nombre = dto.NombreRevista, Estado = 1 };
                _context.Revista.Add(revista);
            }
            else if (!string.IsNullOrWhiteSpace(dto.NombreRevista))
            {
                revista.Nombre = dto.NombreRevista;
                revista.Estado = 1;
            }
            await _context.SaveChangesAsync();

            var entity = new MetadatosRevistaIssn
            {
                IdRevista = dto.IdRevista,
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
            var idRevista = await _repository.CreateAsync(entity);

            // Guardar el ISSN en IssnsRevista si viene en el DTO
            if (!string.IsNullOrWhiteSpace(dto.Issn))
            {
                var existeIssn = await _context.IssnsRevista.AnyAsync(i => i.Issn == dto.Issn && i.IdRevista == dto.IdRevista);
                if (!existeIssn)
                {
                    var issnEntity = new IssnsRevista { IdRevista = dto.IdRevista, Issn = dto.Issn };
                    _context.IssnsRevista.Add(issnEntity);
                    await _context.SaveChangesAsync();
                }
            }
            return idRevista;
        }

        // Actualiza un registro existente de MetadatosRevistaIssn y el nombre en la entidad Revista
        public async Task<bool> UpdateAsync(MetadatosRevistaIssnUpdateDTO dto)
        {
            // Actualiza el nombre en la entidad Revista si viene en el DTO
            var revista = await _context.Revista.FindAsync(dto.IdRevista);
            if (revista != null && !string.IsNullOrWhiteSpace(dto.NombreRevista))
            {
                revista.Nombre = dto.NombreRevista;
                revista.Estado = 1;
                await _context.SaveChangesAsync();
            }

            var entity = new MetadatosRevistaIssn
            {
                IdRevista = dto.IdRevista,
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
            var updated = await _repository.UpdateAsync(entity);

            // Guardar el ISSN en IssnsRevista si viene en el DTO y no existe
            if (!string.IsNullOrWhiteSpace(dto.Issn))
            {
                var existeIssn = await _context.IssnsRevista.AnyAsync(i => i.Issn == dto.Issn && i.IdRevista == dto.IdRevista);
                if (!existeIssn)
                {
                    var issnEntity = new IssnsRevista { IdRevista = dto.IdRevista, Issn = dto.Issn };
                    _context.IssnsRevista.Add(issnEntity);
                    await _context.SaveChangesAsync();
                }
            }
            return updated;
        }
    }
}
