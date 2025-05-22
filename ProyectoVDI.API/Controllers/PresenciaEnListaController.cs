using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenciaEnListasController : ControllerBase
    {
        private readonly IPresenciaEnListasRepository _repository;

        public PresenciaEnListasController(IPresenciaEnListasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PresenciaEnListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresenciaEnListas>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/PresenciaEnListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresenciaEnListas>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/PresenciaEnListas
        [HttpPost]
        public async Task<ActionResult<PresenciaEnListas>> Create(PresenciaEnListas entity)
        {
            var newId = await _repository.CreateAsync(entity);
            entity.IdLista = newId;
            return CreatedAtAction(nameof(GetById), new { id = newId }, entity);
        }

        // PUT: api/PresenciaEnListas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PresenciaEnListas entity)
        {
            if (id != entity.IdLista)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/PresenciaEnListas/5
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
