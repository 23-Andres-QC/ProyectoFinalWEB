using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresenciaEnListasDTOController : ControllerBase
    {
        private readonly IPresenciaEnListasService _presenciaEnListasService;

        public PresenciaEnListasDTOController(IPresenciaEnListasService presenciaEnListasService)
        {
            _presenciaEnListasService = presenciaEnListasService;
        }

        // GET: api/PresenciaEnListasDTO
        [HttpGet]
        public async Task<IActionResult> GetAllPresenciaEnListas()
        {
            var listas = await _presenciaEnListasService.GetPresenciaEnListas();
            return Ok(listas);
        }

        // GET: api/PresenciaEnListasDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPresenciaEnListasById(int id)
        {
            var item = await _presenciaEnListasService.GetPresenciaEnListasById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // POST: api/PresenciaEnListasDTO
        [HttpPost]
        public async Task<IActionResult> CreatePresenciaEnListas([FromBody] PresenciaEnListasCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto PresenciaEnListasCreateDTO es nulo.");
            if (dto.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var newId = await _presenciaEnListasService.CreatePresenciaEnListas(dto);
            return Ok(newId);
        }

        // PUT: api/PresenciaEnListasDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePresenciaEnListas(int id, [FromBody] PresenciaEnListasUpdateDTO dto)
        {
            if (dto == null || dto.IdLista != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (dto.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var result = await _presenciaEnListasService.UpdatePresenciaEnListas(dto);
            if (!result)
                return NotFound();
            return Ok("PresenciaEnListas actualizada correctamente.");
        }

        // DELETE: api/PresenciaEnListasDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresenciaEnListas(int id)
        {
            await _presenciaEnListasService.DeletePresenciaEnListas(id);
            return NoContent();
        }
    }
}
