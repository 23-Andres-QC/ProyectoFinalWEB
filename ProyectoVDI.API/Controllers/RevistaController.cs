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
        private readonly IRevistaService _revistaService;

        public RevistaController(IRevistaListaCerradaService listaCerradaService, IRevistaService revista)
        {
            _listaCerradaService = listaCerradaService;
            _revistaService = revista; // Asegúrate de inyectar correctamente el servicio de revistas
        }

        //crear una bida de revista completaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        // api/revista/registrar

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] RevistaCompletaDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            try
            {
                bool resultado = await _revistaService.RegistrarRevistaCompletaAsync(dto);

                if (resultado)
                    return Ok(new { mensaje = "Revista registrada correctamente." });
                else
                    return StatusCode(500, "No se pudo registrar la revista.");
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error y devolver un mensaje adecuado
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
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
