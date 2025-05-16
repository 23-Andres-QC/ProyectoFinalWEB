using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        // GET: api/editorial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetAll()
        {
            var editoriales = await _editorialRepository.GetAllAsync();
            return Ok(editoriales);
        }

        // GET: api/editorial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetById(int id)
        {
            var editorial = await _editorialRepository.GetByIdAsync(id);
            if (editorial == null)
                return NotFound();

            return Ok(editorial);
        }

        // POST: api/editorial
        [HttpPost]
        public async Task<ActionResult> Create(Editorial editorial)
        {
            var id = await _editorialRepository.CreateAsync(editorial);
            return CreatedAtAction(nameof(GetById), new { id = id }, editorial);
        }

        // PUT: api/editorial/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Editorial editorial)
        {
            if (id != editorial.IdEditorial)
                return BadRequest("ID mismatch");

            var updated = await _editorialRepository.UpdateAsync(editorial);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/editorial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _editorialRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
