using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevistaController : ControllerBase
    {
        private readonly IRevistaService _revistaService;
        private readonly IIssnsRevistaService _issnsService;
        private readonly IMetadatosRevistaIssnService _metadatosService;
        private readonly IRevistaListaCerradaService _listaCerradaService;
        private readonly IRegistroRevistasService _registroService;
        private readonly IDetRegistroRevistaService _detalleService;

        public RevistaController(
            IRevistaService revistaService,
            IIssnsRevistaService issnsService,
            IMetadatosRevistaIssnService metadatosService,
            IRevistaListaCerradaService listaCerradaService,
            IRegistroRevistasService registroService,
            IDetRegistroRevistaService detalleService)
        {
            _revistaService = revistaService;
            _issnsService = issnsService;
            _metadatosService = metadatosService;
            _listaCerradaService = listaCerradaService;
            _registroService = registroService;
            _detalleService = detalleService;
        }

        [HttpPost("/{idUsuario}/{tipo}")]
        public async Task<IActionResult> RegistrarRevistas(int idUsuario, string tipo, [FromBody] List<dynamic> revistasJson)
        {
            // 1. Crear registro principal
            var idRegistro = await _registroService.CreateAsync(new RegistroRevistasCreateDTO { IdUsuario = idUsuario });
            var idsRevistas = new List<int>();

            foreach (var revista in revistasJson)
            {
                // Si el JSON trae idUsuario, ignorarlo y usar el de la URL
                if (revista.idUsuario != null)
                {
                    revista.idUsuario = idUsuario;
                }
                int idRevista = 0;
                if (tipo == "normal")
                {
                    // Buscar por ISSN, si existe actualizar, si no crear
                    string issn = revista.issn;
                    var existentes = await _issnsService.GetAllAsync();
                    var existente = existentes.FirstOrDefault(x => x.Issn == issn);
                    if (existente != null && existente.IdRevista.HasValue)
                    {
                        idRevista = existente.IdRevista.Value;
                        // Actualizar revista y metadatos
                        await _revistaService.UpdateAsync(new RevistaUpdateDTO {
                            IdRevista = idRevista,
                            Nombre = revista.nombre,
                            TipoLista = "normal",
                            Estado = 1
                        });
                        await _metadatosService.UpdateAsync(new MetadatosRevistaIssnUpdateDTO {
                            IdRevista = idRevista,
                            Scopus = revista.scopus,
                            WoSQ = revista.woSQ,
                            WoSEsci = revista.woSEsci,
                            Ajg = revista.ajg,
                            Cnrs = revista.cnrs,
                            Abdc = revista.abdc
                        });
                    }
                    else
                    {
                        idRevista = await _revistaService.CreateAsync(new RevistaCreateDTO {
                            Nombre = revista.nombre,
                            TipoLista = "normal"
                        });
                        await _issnsService.CreateAsync(new IssnsRevistaCreateDTO {
                            IdRevista = idRevista,
                            Issn = issn
                        });
                        await _metadatosService.CreateAsync(new MetadatosRevistaIssnCreateDTO {
                            IdRevista = idRevista,
                            Scopus = revista.scopus,
                            WoSQ = revista.woSQ,
                            WoSEsci = revista.woSEsci,
                            Ajg = revista.ajg,
                            Cnrs = revista.cnrs,
                            Abdc = revista.abdc
                        });
                    }
                }
                else if (tipo == "listaCerrada")
                {
                    var issn1 = revista.issn1;
                    var issn2 = revista.issn2;
                    var issn3 = revista.issn3;
                    var existentes = await _issnsService.GetAllAsync();
                    var grupo = existentes.Where(x => x.Issn == issn1 || x.Issn == issn2 || x.Issn == issn3).ToList();
                    if (grupo.Count == 3)
                    {
                        idRevista = grupo.First().IdRevista ?? 0;
                        await _revistaService.UpdateAsync(new RevistaUpdateDTO {
                            IdRevista = idRevista,
                            Nombre = revista.nombre,
                            TipoLista = "listaCerrada",
                            Estado = 1
                        });
                        await _listaCerradaService.UpdateAsync(new RevistaListaCerradaUpdateDTO {
                            IdRevista = idRevista,
                            Nombre = revista.nombre,
                            Categoria = revista.categoria,
                            Puntaje = revista.puntaje,
                            IncentivoUsd = revista.incentivoUsd
                        });
                    }
                    else
                    {
                        idRevista = await _revistaService.CreateAsync(new RevistaCreateDTO {
                            Nombre = revista.nombre,
                            TipoLista = "listaCerrada"
                        });
                        await _issnsService.CreateAsync(new IssnsRevistaCreateDTO { IdRevista = idRevista, Issn = issn1 });
                        await _issnsService.CreateAsync(new IssnsRevistaCreateDTO { IdRevista = idRevista, Issn = issn2 });
                        await _issnsService.CreateAsync(new IssnsRevistaCreateDTO { IdRevista = idRevista, Issn = issn3 });
                        await _listaCerradaService.CreateAsync(new RevistaListaCerradaCreateDTO {
                            IdRevista = idRevista,
                            Nombre = revista.nombre,
                            Categoria = revista.categoria,
                            Puntaje = revista.puntaje,
                            IncentivoUsd = revista.incentivoUsd
                        });
                    }
                }
                idsRevistas.Add(idRevista);
                await _detalleService.CreateAsync(new DetRegistroRevistaCreateDTO {
                    IdRegistro = idRegistro,
                    IdRevista = idRevista
                });
            }
            return Ok(new { idRegistro, idsRevistas });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _revistaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _revistaService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RevistaUpdateDTO dto)
        {
            if (id != dto.IdRevista) return BadRequest();
            var updated = await _revistaService.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Cambia el estado a 0 (borrado lógico)
            var updated = await _revistaService.ChangeEstadoAsync(id, 0);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
