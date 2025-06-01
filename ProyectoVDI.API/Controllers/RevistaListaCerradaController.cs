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
    public class RevistaListaCerradaController : ControllerBase
    {
        private readonly IRevistaListaCerradaService _service;
        public RevistaListaCerradaController(IRevistaListaCerradaService service)
        {
            _service = service;
        }

        // Obtener toda la lista cerrada
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // Importar lista cerrada desde Excel (reemplaza todo)
        [HttpPost("importar")]
        public async Task<IActionResult> ImportarListaCerrada([FromForm] IFormFile archivoExcel)
        {
            if (archivoExcel == null || archivoExcel.Length == 0)
                return BadRequest("Debe subir un archivo Excel válido.");

            using (var ms = new System.IO.MemoryStream())
            {
                await archivoExcel.CopyToAsync(ms);
                var result = await _service.ImportarDesdeExcelAsync(ms.ToArray());
                if (!result)
                    return StatusCode(500, "Error al importar la lista cerrada.");
                return Ok("Lista cerrada importada correctamente.");
            }
        }
    }
}
