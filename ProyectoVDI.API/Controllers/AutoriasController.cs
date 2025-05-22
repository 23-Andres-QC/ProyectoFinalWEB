using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoriasController : ControllerBase
    {
        private readonly IAutoriaRepository _repository;

        public AutoriasController(IAutoriaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Autorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autoria>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Autorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autoria>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/Autorias
        [HttpPost]
        public async Task<ActionResult<Autoria>> Create(Autoria entity)
        {
            await _repository.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdAutoria }, entity);
        }

        // PUT: api/Autorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Autoria entity)
        {
            if (id != entity.IdAutoria)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/Autorias/5
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
