using Microsoft.AspNetCore.Http;
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
        private readonly IRevistaListaCerradaService _listaCerradaService;

        public RevistaController(IRevistaListaCerradaService listaCerradaService)
        {
            _listaCerradaService = listaCerradaService;
        }

        // Obtener toda la lista cerrada
        [HttpGet("lista-cerrada")]
        public async Task<IActionResult> GetListaCerrada()
        {
            var result = await _listaCerradaService.GetAllAsync();
            return Ok(result);
        }

        // Importar lista cerrada desde Excel (reemplaza todo)
        [HttpPost("lista-cerrada/importar")]
        public async Task<IActionResult> ImportarListaCerrada([FromForm] IFormFile archivoExcel)
        {
            if (archivoExcel == null || archivoExcel.Length == 0)
                return BadRequest("Debe subir un archivo Excel válido.");

            using (var ms = new System.IO.MemoryStream())
            {
                await archivoExcel.CopyToAsync(ms);
                var result = await _listaCerradaService.ImportarDesdeExcelAsync(ms.ToArray());
                if (!result)
                    return StatusCode(500, "Error al importar la lista cerrada.");
                return Ok("Lista cerrada importada correctamente.");
            }
        }
    }
}
