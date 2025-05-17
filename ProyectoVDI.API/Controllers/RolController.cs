using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        // GET: api/rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetAll()
        {
            var roles = await _rolRepository.GetAllAsync();
            return Ok(roles);
        }

        // GET: api/rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        // POST: api/rol
        [HttpPost]
        public async Task<ActionResult> Create(Rol item)
        {
            var id = await _rolRepository.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = id }, item);
        }

        // PUT: api/rol/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Rol item)
        {
            if (id != item.IdRol)
                return BadRequest("ID mismatch");

            var updated = await _rolRepository.UpdateAsync(item);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/rol/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _rolRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}