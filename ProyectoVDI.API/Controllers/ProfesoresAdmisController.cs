using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresAdmisController : ControllerBase
    {
        // Inyección de dependencia del servicio de profesores
        private readonly IProfesoresAdmisService _service;
        public ProfesoresAdmisController(IProfesoresAdmisService service)
        {
            _service = service;
        }

        // Función: Obtener la lista de todos los profesores
        // Método: GET
        // Ruta: api/profesoresadmis
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // Función: Obtener el detalle de un profesor por su ID
        // Método: GET
        // Ruta: api/profesoresadmis/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Función: Registrar uno o varios profesores (importación masiva o registro individual)
        // Método: POST
        // Ruta: api/profesoresadmis
        // Body: [ { ... }, { ... } ]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<ProfesoresAdmisCreateDTO> profesores)
        {
            var ids = new List<int>();
            foreach (var dto in profesores)
            {
                var id = await _service.CreateAsync(dto);
                ids.Add(id);
            }
            return Ok(ids);
        }

        // Función: Actualizar los datos de un profesor existente
        // Método: PUT
        // Ruta: api/profesoresadmis/{id}
        // Body: { ... }
        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] ProfesoresAdmisUpdateDTO dto)
        {
            
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // Función: Eliminar un profesor por su ID
        // Método: DELETE
        // Ruta: api/profesoresadmis/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
