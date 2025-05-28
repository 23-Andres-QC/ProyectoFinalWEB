using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
//s
namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroIssnController : ControllerBase
    {
        private readonly IRegistroISSNRepository _registroISSNRepository;

        public RegistroIssnController(IRegistroISSNRepository registroISSNRepository)
        {
            _registroISSNRepository = registroISSNRepository;
        }

        // GET: api/RegistroIssn
        // Devuelve la lista completa de registros ISSN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroIssn>>> GetAll()
        {
            var registros = await _registroISSNRepository.GetAllAsync();
            return Ok(registros);
        }

        // GET: api/RegistroIssn/5
        // Devuelve un solo registro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroIssn>> GetById(int id)
        {
            var registro = await _registroISSNRepository.GetByIdAsync(id);

            if (registro == null)
                return NotFound(); // Si no existe, devuelve 404

            return Ok(registro);
        }

        // POST: api/RegistroIssn
        // Crea un nuevo registro ISSN
        [HttpPost]
        public async Task<ActionResult<RegistroIssn>> Create(RegistroIssn registro)
        {
            await _registroISSNRepository.CreateAsync(registro);

            // Devuelve 201 con la ubicación del nuevo recurso
            return CreatedAtAction(nameof(GetById), new { id = registro.IdRegistroIssn }, registro);
        }

        // PUT: api/RegistroIssn/5
        // Actualiza un registro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegistroIssn registro)
        {
            if (id != registro.IdRegistroIssn)
                return BadRequest("El ID no coincide."); // Evita actualizar otro registro por error

            await _registroISSNRepository.UpdateAsync(registro);
            return NoContent(); // Devuelve 204 cuando la actualización fue exitosa
        }

        // DELETE: api/RegistroIssn/5
        // Elimina un registro por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _registroISSNRepository.DeleteAsync(id);
            return NoContent(); // Devuelve 204 al eliminar correctamente
        }


    }
}
