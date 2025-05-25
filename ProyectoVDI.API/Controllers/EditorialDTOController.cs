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
    public class EditorialDTOController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialDTOController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        // GET: api/EditorialDTO
        [HttpGet]
        public async Task<IActionResult> GetAllEditoriales()
        {
            var editoriales = await _editorialService.GetEditoriales();
            return Ok(editoriales);
        }

        // GET: api/EditorialDTO/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorialById(int id)
        {
            var editorial = await _editorialService.GetEditorialById(id);
            if (editorial == null)
                return NotFound();
            return Ok(editorial);
        }

        // POST: api/EditorialDTO
        [HttpPost]
        public async Task<IActionResult> CreateEditorial([FromBody] EditorialCreateDTO editorialCreateDTO)
        {
            if (editorialCreateDTO == null)
                return BadRequest("El objeto EditorialCreateDTO es nulo.");
            if (editorialCreateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var newId = await _editorialService.CreateEditorial(editorialCreateDTO);
            return Ok(newId);
        }

        // PUT: api/EditorialDTO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEditorial(int id, [FromBody] EditorialUpdateDTO editorialUpdateDTO)
        {
            if (editorialUpdateDTO == null || editorialUpdateDTO.IdEditorial != id)
                return BadRequest("El objeto es nulo o el ID no coincide.");
            if (editorialUpdateDTO.IdRevista == null)
                return BadRequest("El campo 'IdRevista' es obligatorio.");
            var result = await _editorialService.UpdateEditorial(editorialUpdateDTO);
            if (!result)
                return NotFound();
            return Ok("Editorial actualizada correctamente.");
        }

        // DELETE: api/EditorialDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            await _editorialService.DeleteEditorial(id);
            return NoContent();
        }
    }
}
