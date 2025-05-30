using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevistaController : ControllerBase
    {
        private readonly IRevistaService _service;

        public RevistaController(IRevistaService service)
        {
            _service = service;
        }

        // Simple list
        [HttpGet("simple")]
        public async Task<ActionResult<IEnumerable<RevistaListDTO>>> GetRevista()
        {
            var revistas = await _service.GetRevista();
            return Ok(revistas);
        }

        // Simple by id
        [HttpGet("simple/{id}")]
        public async Task<ActionResult<RevistaDTO>> GetRevistaById(int id)
        {
            var revista = await _service.GetRevistaById(id);
            if (revista == null) return NotFound();
            return Ok(revista);
        }

        // Full list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevistaFullDTO>>> GetRevistas()
        {
            var revistas = await _service.GetRevistas();
            return Ok(revistas);
        }

        // Full by id
        [HttpGet("{id}")]
        public async Task<ActionResult<RevistaFullDTO>> GetRevistasById(int id)
        {
            var revista = await _service.GetRevistasById(id);
            if (revista == null) return NotFound();
            return Ok(revista);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RevistaCreateDTO dto)
        {
            var id = await _service.CreateRevista(dto);
            return CreatedAtAction(nameof(GetRevistaById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<String> Update(int id, [FromBody] RevistaUpdateDTO dto)
        {
            dto.IdRevista = id; // Asigna el id de la URL al DTO
            var updated = await _service.UpdateRevista(dto);
            if (!updated) return "No se puede actualizar";
            return "Registrado";
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRevista(id);
            return Ok(id);
        }
    }
}