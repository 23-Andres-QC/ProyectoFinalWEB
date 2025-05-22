using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _repository;

        public EditorialController(IEditorialRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Editorial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Editorial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/Editorial
        [HttpPost]
        public async Task<ActionResult<Editorial>> Create(Editorial entity)
        {
            int newId = await _repository.CreateAsync(entity);
            entity.IdEditorial = newId; // Asegúrate que esta propiedad exista en la clase
            return CreatedAtAction(nameof(GetById), new { id = newId }, entity);
        }

        // PUT: api/Editorial/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Editorial entity)
        {
            if (id != entity.IdEditorial) // Ajusta el nombre del ID si es distinto
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/Editorial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
