using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevistaController : ControllerBase
    {
        private readonly IRevistaRegistroService _service;
        private readonly IRevistaListaCerradaService _lcdService;

        public RevistaController(IRevistaRegistroService service, IRevistaListaCerradaService lcdService)
        {
            _service = service;
            _lcdService = lcdService;
        }

        // GET: api/Revista
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllRevistasAsync();
            return Ok(result);
        }

        // GET: api/Revista/{issn}
        [HttpGet("{issn}")]
        public async Task<IActionResult> GetByIssn(string issn)
        {
            var result = await _service.GetRevistaByIssnAsync(issn);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/Revista/campos-basicos
        [HttpGet("campos-basicos")]
        public async Task<IActionResult> GetCamposBasicos()
        {
            var result = await _service.GetCamposBasicosAsync();
            return Ok(result);
        }

        // GET: api/Revista/campos-basicos/{issn}
        [HttpGet("campos-basicos/{issn}")]
        public async Task<IActionResult> GetCamposBasicosByIssn(string issn)
        {
            var result = await _service.GetCamposBasicosByIssnAsync(issn);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Revista?idUsuario=1&tipoRevista=SCI o LCD
        [HttpPost]
        public async Task<IActionResult> RegistrarRevistas(
            [FromQuery] int idUsuario,
            [FromQuery] string tipoRevista,
            [FromBody] object revistas)
        {
            if (tipoRevista == "SCI")
            {
                var revistasList = System.Text.Json.JsonSerializer.Deserialize<List<RevistaRegistroDTO>>(revistas.ToString() ?? "[]");
                if (revistasList == null) return BadRequest("Formato de revistas inválido para SCI");
                var result = await _service.RegistrarRevistasAsync(idUsuario, tipoRevista, revistasList);
                if (result) return Ok();
                return BadRequest();
            }
            else if (tipoRevista == "LCD")
            {
                var revistasList = System.Text.Json.JsonSerializer.Deserialize<List<ListaCerradaRegistroDTO>>(revistas.ToString() ?? "[]");
                if (revistasList == null) return BadRequest("Formato de revistas inválido para LCD");
                var result = await _lcdService.RegistrarLCDAsync(idUsuario, revistasList);
                if (result) return Ok();
                return BadRequest();
            }
            else
            {
                return BadRequest("Tipo de revista no soportado");
            }
        }

        // PUT: api/Revista
        [HttpPut]
        public async Task<IActionResult> ActualizarRevista([FromQuery] string tipoRevista, [FromBody] object dto)
        {
            if (tipoRevista == "SCI")
            {
                var revistaDto = System.Text.Json.JsonSerializer.Deserialize<RevistaRegistroDTO>(dto.ToString() ?? "{}");
                if (revistaDto == null) return BadRequest("Formato inválido para SCI");
                var result = await _service.ActualizarRevistaPorIssnAsync(revistaDto);
                if (result) return Ok();
                return NotFound();
            }
            else if (tipoRevista == "LCD")
            {
                var lcdDto = System.Text.Json.JsonSerializer.Deserialize<ListaCerradaRegistroDTO>(dto.ToString() ?? "{}");
                if (lcdDto == null) return BadRequest("Formato inválido para LCD");
                var result = await _lcdService.ActualizarLCDPorIssnAsync(lcdDto);
                if (result) return Ok();
                return NotFound();
            }
            else
            {
                return BadRequest("Tipo de revista no soportado");
            }
        }

        // DELETE: api/Revista/{issn}
        [HttpDelete("{issn}")]
        public async Task<IActionResult> EliminarRevista(string issn, [FromQuery] string tipoRevista)
        {
            if (tipoRevista == "SCI")
            {
                var result = await _service.EliminarRevistaPorIssnAsync(issn);
                if (result) return Ok();
                return NotFound();
            }
            else if (tipoRevista == "LCD")
            {
                var result = await _lcdService.EliminarLCDPorIssnAsync(issn);
                if (result) return Ok();
                return NotFound();
            }
            else
            {
                return BadRequest("Tipo de revista no soportado");
            }
        }

        // GET: api/Revista/lcd
        [HttpGet("lcd")]
        public async Task<IActionResult> GetAllLCD()
        {
            var result = await _lcdService.GetAllLCDAsync();
            return Ok(result);
        }

        // GET: api/Revista/lcd/{issn}
        [HttpGet("lcd/{issn}")]
        public async Task<IActionResult> GetLCDByIssn(string issn)
        {
            var result = await _lcdService.GetLCDByIssnAsync(issn);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/Revista/categorias-listacerrada
        [HttpGet("categorias-listacerrada")]
        public async Task<IActionResult> GetCategoriasListaCerrada()
        {
            var categorias = await _lcdService.GetDistinctCategoriasAsync();
            return Ok(categorias);
        }

        // GET: api/Revista/columnas-listacerrada
        [HttpGet("columnas-listacerrada")]
        public async Task<IActionResult> GetColumnasListaCerrada()
        {
            var columnas = await _lcdService.GetColumnNamesAsync();
            return Ok(columnas);
        }

        // GET: api/Revista/distinct-listacerrada/{columna}
        [HttpGet("distinct-listacerrada/{columna}")]
        public async Task<IActionResult> GetDistinctValoresListaCerrada(string columna)
        {
            var valores = await _lcdService.GetDistinctValuesAsync(columna);
            return Ok(valores);
        }

        // GET: api/Revista/columnas-metadatos
        [HttpGet("columnas-metadatos")]
        public async Task<IActionResult> GetColumnasMetadatos()
        {
            var columnas = await _service.GetMetadatosColumnNamesAsync();
            return Ok(columnas);
        }

        // GET: api/Revista/distinct-metadatos/{columna}
        [HttpGet("distinct-metadatos/{columna}")]
        public async Task<IActionResult> GetDistinctValoresMetadatos(string columna)
        {
            var valores = await _service.GetMetadatosDistinctValuesAsync(columna);
            return Ok(valores);
        }
    }
}
