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
    public class RevistaDTOController : ControllerBase
    {
        private readonly IRevistaService _revistaService;

        public RevistaDTOController(IRevistaService revistaService)
        {
            _revistaService = revistaService;
        }

        // GET: api/RevistaDTO
        [HttpGet]
        public async Task<IActionResult> GetAllRevistas()
        {
            var revistas = await _revistaService.GetRevistas();
            return Ok(revistas);
        }

        // GET: api/RevistaDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRevistaById(int id)
        {
            var revista = await _revistaService.GetRevistaById(id);
            if (revista == null)
                return NotFound();
            return Ok(revista);
        }

        // POST: api/RevistaDTO
        [HttpPost]
        public async Task<IActionResult> CreateRevista([FromBody] RevistaCreateDTO revistaCreateDTO)
        {
            if (revistaCreateDTO == null)
                return BadRequest("El objeto RevistaCreateDTO es nulo.");
            if (string.IsNullOrWhiteSpace(revistaCreateDTO.Nombre))
                return BadRequest("El campo 'Nombre' es obligatorio.");
            if (string.IsNullOrWhiteSpace(revistaCreateDTO.Issn))
                return BadRequest("El campo 'Issn' es obligatorio.");
            var newId = await _revistaService.CreateRevista(revistaCreateDTO);
            return Ok(newId);
        }

        // PUT: api/RevistaDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRevista(int id, [FromBody] RevistaUpdateDTO revistaUpdateDTO)
        {
            if (revistaUpdateDTO == null || revistaUpdateDTO.IdRevista != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (string.IsNullOrWhiteSpace(revistaUpdateDTO.Nombre))
                return BadRequest("El campo 'Nombre' es obligatorio.");
            if (string.IsNullOrWhiteSpace(revistaUpdateDTO.Issn))
                return BadRequest("El campo 'Issn' es obligatorio.");
            var result = await _revistaService.UpdateRevista(revistaUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Revista actualizada correctamente.");
        }

        // DELETE: api/RevistaDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevista(int id)
        {
            await _revistaService.DeleteRevista(id);
            return NoContent();
        }
    }
}
