using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Repositories;
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


        //crear una nueva revista completaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public async Task<bool> RegistrarRevistaCompletaAsync(RevistaCompletaDTO dto)
        {
            try
            {
                // 1. Crear entidad REVISTA
                var revista = new Revista
                {
                    Nombre = dto.Nombre,
                    TipoLista = dto.TipoLista,
                    Estado = dto.Estado
                };

                // 2. Crear lista de ISSNs (puede ser null)
                List<IssnsRevista>? listaIssns = null;
                if (dto.TipoLista == "ISSN" && dto.ListaIssns != null && dto.ListaIssns.Any())
                {
                    listaIssns = dto.ListaIssns.Select(issn => new IssnsRevista
                    {
                        Issn = issn
                    }).ToList();
                }

                // 3. Crear METADATOS solo si TipoLista es ISSN
                MetadatosRevistaIssn? metadatos = null;
                if (dto.TipoLista == "ISSN")
                {
                    metadatos = new MetadatosRevistaIssn
                    {
                        Scopus = dto.Scopus,                         // 1
                        WoSQ = dto.WoSQ,                             // 2
                        WoSS = dto.WoSS,                             // 3
                        WoSEsci = dto.WoSEsci,                       // 4
                        EsciQ = dto.EsciQ,                           // 5

                        Ajg4star = dto.Ajg4star,                     // 6
                        Ajg = dto.Ajg,                               // 7
                        AjgS = dto.AjgS,                             // 8
                        Cnrs = dto.Cnrs,                             // 9
                        CnrsS = dto.CnrsS,                           // 10

                        Abdc = dto.Abdc,                             // 11
                        AbdcS = dto.AbdcS,                           // 12
                        AlMenosUnaLista = dto.AlMenosUnaLista,      // 13
                        SoloUnaLista = dto.SoloUnaLista,            // 14
                        Scielo = dto.Scielo,                         // 15

                        WoSLatam = dto.WoSLatam,                     // 16
                        Top50 = dto.Top50,                           // 17
                        N = dto.N,                                   // 18
                        BeallsList = dto.BeallsList,                 // 19
                        Mdpi = dto.Mdpi,                             // 20

                        Insights = dto.Insights,                     // 21
                        AjgExiste = dto.AjgExiste,                   // 22
                        CnrsExiste = dto.CnrsExiste,                 // 23
                        AbdcExiste = dto.AbdcExiste,                 // 24
                        WoSTopExiste = dto.WoSTopExiste,             // 25

                        WoSEsciExiste = dto.WoSEsciExiste,           // 26
                        ScopusExiste = dto.ScopusExiste,             // 27
                        SoloScieloExiste = dto.SoloScieloExiste,     // 28
                        Especial216b = dto.Especial216b,             // 29
                        LatamSinEsciExiste = dto.LatamSinEsciExiste, // 30

                        EsciScieloSinScopus = dto.EsciScieloSinScopus, // 31
                        Multiple = dto.Multiple,                      // 32
                        MultidisciplinaryWos = dto.MultidisciplinaryWos, // 33
                        CoautoriaEsan = dto.CoautoriaEsan,           // 34
                        PosicionAutor = dto.PosicionAutor,           // 35

                        Jif = dto.Jif,                               // 36
                        Country = dto.Country,                       // 37
                        MultyAlMenosUnaLista = dto.MultyAlMenosUnaLista, // 38
                        MultidisciplinaryScopus = dto.MultidisciplinaryScopus, // 39
                        MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys // 40
                    };
                }

                // 4. Crear REGISTRO
                var registro = new RegistroRevistas
                {
                    IdUsuario = dto.IdUsuario,
                    FechaRegistro = DateTime.Now
                };

                // 5. Llamar al repositorio
                var resultado = await _repository.CreateAsync(revista, listaIssns, metadatos, registro);

                // 6. Devolver resultado
                return resultado;
            }
            catch (Exception ex)
            {
                // 7. Manejo de error
                throw new Exception("Error al registrar la revista completa", ex);
            }
        }







        public async Task<IEnumerable<RevistaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<RevistaListDTO>();
            foreach (var item in list)
            {
                result.Add(new RevistaListDTO
                {
                    IdRevista = item.IdRevista,
                    Nombre = item.Nombre,
                    TipoLista = item.TipoLista,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<RevistaDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new RevistaDetailDTO
            {
                IdRevista = item.IdRevista,
                Nombre = item.Nombre,
                TipoLista = item.TipoLista,
                Estado = item.Estado
            };
        }

        public async Task<int> CreateAsync(RevistaCreateDTO dto)
        {
            var entity = new Revista
            {
                Nombre = dto.Nombre,
                TipoLista = dto.TipoLista,
                Estado = 1
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(RevistaUpdateDTO dto)
        {
            var entity = new Revista
            {
                IdRevista = dto.IdRevista,
                Nombre = dto.Nombre,
                TipoLista = dto.TipoLista,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> ChangeEstadoAsync(int id, int estado)
        {
            var revista = await _repository.GetByIdAsync(id);
            if (revista == null) return false;
            revista.Estado = estado;
            return await _repository.UpdateAsync(revista);
        }
    }
}
