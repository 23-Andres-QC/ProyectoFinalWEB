using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetRegistroIssnController : ControllerBase
    {
        private readonly IDetRegistroISSNRepository _repository;

        public DetRegistroIssnController(IDetRegistroISSNRepository repository)
        {
            _repository = repository;
        }

        // GET: api/DetRegistroIssn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetRegistroIssn>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/DetRegistroIssn/registro/5
        [HttpGet("registro/{idRegistroIssn}")]
        public async Task<ActionResult<IEnumerable<DetRegistroIssn>>> GetByRegistroId(int idRegistroIssn)
        {
            var result = await _repository.GetByRegistroIdAsync(idRegistroIssn);
            return Ok(result);
        }

        // POST: No se puede

        // PUT: api/DetRegistroIssn/5/10
        [HttpPut("{idRegistroIssn}/{idRevista}")]
        public async Task<IActionResult> Update(int idRegistroIssn, int idRevista, DetRegistroIssn entity)
        {
            if (entity.IdRegistroIssn != idRegistroIssn || entity.IdRevista != idRevista)
                return BadRequest("Los IDs proporcionados no coinciden con el objeto.");

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/DetRegistroIssn/5/10
        [HttpDelete("{idRegistroIssn}/{idRevista}")]
        public async Task<IActionResult> Delete(int idRegistroIssn, int idRevista)
        {
            await _repository.DeleteAsync(idRegistroIssn, idRevista);
            return NoContent();
        }
    }
}
