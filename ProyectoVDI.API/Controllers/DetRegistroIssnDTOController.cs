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
    public class DetRegistroIssnDTOController : ControllerBase
    {
        private readonly IDetRegistroIssnService _service;

        public DetRegistroIssnDTOController(IDetRegistroIssnService service)
        {
            _service = service;
        }

        // GET: api/DetRegistroIssnDTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalles = await _service.GetDetRegistroIssn();
            return Ok(detalles);
        }

        // GET: api/DetRegistroIssnDTO/compuesto?idRegistroIssn=1&idRevista=2
        [HttpGet("compuesto")]
        public async Task<IActionResult> GetById([FromQuery] int idRegistroIssn, [FromQuery] int idRevista)
        {
            var det = await _service.GetDetRegistroIssnById(idRegistroIssn, idRevista);
            if (det == null)
                return NotFound();
            return Ok(det);
        }

        // POST: api/DetRegistroIssnDTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetRegistroIssnCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto DetRegistroIssnCreateDTO es nulo.");
            if (dto.IdRegistroIssn == null || dto.IdRevista == null)
                return BadRequest("Los campos 'IdRegistroIssn' y 'IdRevista' son obligatorios.");
            var newId = await _service.CreateDetRegistroIssn(dto);
            return Ok(newId);
        }

        // PUT: api/DetRegistroIssnDTO/compuesto?idRegistroIssn=1&idRevista=2
        [HttpPut("compuesto")]
        public async Task<IActionResult> Update([FromQuery] int idRegistroIssn, [FromQuery] int idRevista, [FromBody] DetRegistroIssnUpdateDTO dto)
        {
            if (dto == null || dto.IdRegistroIssn != idRegistroIssn || dto.IdRevista != idRevista)
                return BadRequest("El objeto es nulo o los IDs no coinciden.");
            var result = await _service.UpdateDetRegistroIssn(dto);
            if (!result)
                return NotFound();
            return Ok("Detalle actualizado correctamente.");
        }

        // DELETE: api/DetRegistroIssnDTO/compuesto?idRegistroIssn=1&idRevista=2
        [HttpDelete("compuesto")]
        public async Task<IActionResult> Delete([FromQuery] int idRegistroIssn, [FromQuery] int idRevista)
        {
            await _service.DeleteDetRegistroIssn(idRegistroIssn, idRevista);
            return NoContent();
        }
    }
}
