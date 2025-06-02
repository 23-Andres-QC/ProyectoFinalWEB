using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    // Controlador para exponer los endpoints de MetadatosRevistaIssn
    [ApiController]
    [Route("api/[controller]")]
    public class MetadatosRevistaIssnController : ControllerBase
    {
        // Servicio de MetadatosRevistaIssn inyectado por dependencia
        private readonly IMetadatosRevistaIssnService _service;
        public MetadatosRevistaIssnController(IMetadatosRevistaIssnService service)
        {
            _service = service;
        }

        // GET: api/metadatosrevistaissn
        // Obtiene todos los registros para visualización en tabla, incluyendo el nombre de la revista
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/metadatosrevistaissn/{id}
        // Obtiene el detalle de un registro por su ID, incluyendo el nombre de la revista
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/metadatosrevistaissn/importar-json
        // Importa una lista de registros desde un array JSON. Si el ISSN ya existe, actualiza solo los campos no nulos del JSON recibido.
        [HttpPost("importar-json")]
        public async Task<IActionResult> ImportarDesdeJson([FromBody] List<MetadatosRevistaIssnCreateDTO> lista)
        {
            int count = 0;
            foreach (var dto in lista)
            {
                var existente = await _service.GetByIdAsync(dto.IdRevista);
                if (existente != null)
                {
                    // Solo actualiza los campos que vienen en el JSON (no nulos)
                    var updateDto = new MetadatosRevistaIssnUpdateDTO
                    {
                        IdRevista = dto.IdRevista,
                        NombreRevista = dto.NombreRevista ?? existente.NombreRevista,
                        Issn = dto.Issn ?? existente.Issn,
                        Scopus = dto.Scopus ?? existente.Scopus,
                        WoSQ = dto.WoSQ ?? existente.WoSQ,
                        WoSS = dto.WoSS ?? existente.WoSS,
                        WoSEsci = dto.WoSEsci ?? existente.WoSEsci,
                        EsciQ = dto.EsciQ ?? existente.EsciQ,
                        Ajg4star = dto.Ajg4star ?? existente.Ajg4star,
                        Ajg = dto.Ajg ?? existente.Ajg,
                        AjgS = dto.AjgS ?? existente.AjgS,
                        Cnrs = dto.Cnrs ?? existente.Cnrs,
                        CnrsS = dto.CnrsS ?? existente.CnrsS,
                        Abdc = dto.Abdc ?? existente.Abdc,
                        AbdcS = dto.AbdcS ?? existente.AbdcS,
                        AlMenosUnaLista = dto.AlMenosUnaLista ?? existente.AlMenosUnaLista,
                        SoloUnaLista = dto.SoloUnaLista ?? existente.SoloUnaLista,
                        Scielo = dto.Scielo ?? existente.Scielo,
                        WoSLatam = dto.WoSLatam ?? existente.WoSLatam,
                        Top50 = dto.Top50 ?? existente.Top50,
                        N = dto.N ?? existente.N,
                        BeallsList = dto.BeallsList ?? existente.BeallsList,
                        Mdpi = dto.Mdpi ?? existente.Mdpi,
                        Insights = dto.Insights ?? existente.Insights,
                        AjgExiste = dto.AjgExiste ?? existente.AjgExiste,
                        CnrsExiste = dto.CnrsExiste ?? existente.CnrsExiste,
                        AbdcExiste = dto.AbdcExiste ?? existente.AbdcExiste,
                        WoSTopExiste = dto.WoSTopExiste ?? existente.WoSTopExiste,
                        WoSEsciExiste = dto.WoSEsciExiste ?? existente.WoSEsciExiste,
                        ScopusExiste = dto.ScopusExiste ?? existente.ScopusExiste,
                        SoloScieloExiste = dto.SoloScieloExiste ?? existente.SoloScieloExiste,
                        Especial216b = dto.Especial216b ?? existente.Especial216b,
                        LatamSinEsciExiste = dto.LatamSinEsciExiste ?? existente.LatamSinEsciExiste,
                        EsciScieloSinScopus = dto.EsciScieloSinScopus ?? existente.EsciScieloSinScopus,
                        Multiple = dto.Multiple ?? existente.Multiple,
                        MultidisciplinaryWos = dto.MultidisciplinaryWos ?? existente.MultidisciplinaryWos,
                        CoautoriaEsan = dto.CoautoriaEsan ?? existente.CoautoriaEsan,
                        PosicionAutor = dto.PosicionAutor ?? existente.PosicionAutor,
                        Jif = dto.Jif ?? existente.Jif,
                        Country = dto.Country ?? existente.Country,
                        MultyAlMenosUnaLista = dto.MultyAlMenosUnaLista ?? existente.MultyAlMenosUnaLista,
                        MultidisciplinaryScopus = dto.MultidisciplinaryScopus ?? existente.MultidisciplinaryScopus,
                        MultidisciplinaryWosOScopys = dto.MultidisciplinaryWosOScopys ?? existente.MultidisciplinaryWosOScopys
                    };
                    await _service.UpdateAsync(updateDto);
                }
                else
                {
                    await _service.CreateAsync(dto);
                }
                count++;
            }
            return Ok(new { message = $"Se importaron o actualizaron {count} registros correctamente." });
        }

        // PUT: api/metadatosrevistaissn/{id}
        // Actualiza un registro existente y el nombre de la revista en la entidad Revista
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MetadatosRevistaIssnUpdateDTO dto)
        {
            if (id != dto.IdRevista) return BadRequest();
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // No se permite eliminar registros, por lo que no hay endpoint DELETE
    }
}