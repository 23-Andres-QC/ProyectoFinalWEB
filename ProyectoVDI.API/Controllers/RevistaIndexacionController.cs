using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistaIndexacionController : ControllerBase
    {
        private readonly IRevistasIndexacionRepository _repository;

        public RevistaIndexacionController(IRevistasIndexacionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/revistaindexacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevistaIndexacion>>> GetAll()
        {
            var revistas = await _repository.GetAllAsync();
            return Ok(revistas);
        }

        // GET: api/revistaindexacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RevistaIndexacion>> GetById(int id)
        {
            var revista = await _repository.GetByIdAsync(id);
            if (revista == null)
                return NotFound();

            return Ok(revista);
        }

        // POST: api/revistaindexacion
        [HttpPost]
        public async Task<ActionResult> Create(RevistaIndexacion item)
        {
            var id = await _repository.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = id }, item);
        }

        // PUT: api/revistaindexacion/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RevistaIndexacion item)
        {
            if (id != item.IdRevistaIndexacion)
                return BadRequest("ID mismatch");

            var updated = await _repository.UpdateAsync(item);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/revistaindexacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
