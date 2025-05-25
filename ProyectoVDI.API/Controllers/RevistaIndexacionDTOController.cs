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
    public class RevistaIndexacionDTOController : ControllerBase
    {
        private readonly IRevistaIndexacionService _service;

        public RevistaIndexacionDTOController(IRevistaIndexacionService service)
        {
            _service = service;
        }

        // GET: api/RevistaIndexacionDTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var indexaciones = await _service.GetRevistaIndexaciones();
            return Ok(indexaciones);
        }

        // GET: api/RevistaIndexacionDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var idx = await _service.GetRevistaIndexacionById(id);
            if (idx == null)
                return NotFound();
            return Ok(idx);
        }

        // POST: api/RevistaIndexacionDTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RevistaIndexacionCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("El objeto RevistaIndexacionCreateDTO es nulo.");
            if (dto.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var newId = await _service.CreateRevistaIndexacion(dto);
            return Ok(newId);
        }

        // PUT: api/RevistaIndexacionDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RevistaIndexacionUpdateDTO dto)
        {
            if (dto == null || dto.IdIndexacion != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (dto.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var result = await _service.UpdateRevistaIndexacion(dto);
            if (!result)
                return NotFound();
            return Ok("Indexación actualizada correctamente.");
        }

        // DELETE: api/RevistaIndexacionDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRevistaIndexacion(id);
            return NoContent();
        }
    }
}
