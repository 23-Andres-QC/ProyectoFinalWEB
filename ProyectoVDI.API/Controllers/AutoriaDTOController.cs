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
    public class AutoriaDTOController : ControllerBase
    {
        private readonly IAutoriaService _autoriaService;

        public AutoriaDTOController(IAutoriaService autoriaService)
        {
            _autoriaService = autoriaService;
        }

        // GET: api/AutoriaDTO
        [HttpGet]
        public async Task<IActionResult> GetAllAutorias()
        {
            var autorias = await _autoriaService.GetAutorias();
            return Ok(autorias);
        }

        // GET: api/AutoriaDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoriaById(int id)
        {
            var autoria = await _autoriaService.GetAutoriaById(id);
            if (autoria == null)
                return NotFound();
            return Ok(autoria);
        }

        // POST: api/AutoriaDTO
        [HttpPost]
        public async Task<IActionResult> CreateAutoria([FromBody] AutoriaCreateDTO autoriaCreateDTO)
        {
            if (autoriaCreateDTO == null)
                return BadRequest("El objeto AutoriaCreateDTO es nulo.");
            if (autoriaCreateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var newId = await _autoriaService.CreateAutoria(autoriaCreateDTO);
            return Ok(newId);
        }

        // PUT: api/AutoriaDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutoria(int id, [FromBody] AutoriaUpdateDTO autoriaUpdateDTO)
        {
            if (autoriaUpdateDTO == null || autoriaUpdateDTO.IdAutoria != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (autoriaUpdateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var result = await _autoriaService.UpdateAutoria(autoriaUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Autoria actualizada correctamente.");
        }

        // DELETE: api/AutoriaDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoria(int id)
        {
            await _autoriaService.DeleteAutoria(id);
            return NoContent();
        }
    }
}
