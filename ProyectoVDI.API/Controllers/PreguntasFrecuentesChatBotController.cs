using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasFrecuentesChatBotController : ControllerBase
    {

        private readonly IPreguntasFrecuentesChatBotRepository _preguntasFrecuentesChatBotRepository;

        public PreguntasFrecuentesChatBotController(IPreguntasFrecuentesChatBotRepository preguntasFrecuentesChatBotRepository)
        {
            _preguntasFrecuentesChatBotRepository = preguntasFrecuentesChatBotRepository;
        }

        // POST: crear una pregunta frecuente
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            if (preguntasFrecuentesChatBot == null)
            {
                return BadRequest(false); // Devuelve false si el objeto es nulo
            }

            try
            {
                await _preguntasFrecuentesChatBotRepository.CreateAsync(preguntasFrecuentesChatBot);
                return Ok(true); // Todo bien, devuelve true
            }
            catch (Exception)
            {
                return BadRequest(false); // Ocurrió un error, devuelve false
            }
        }


        // GET: obtener todas las preguntas frecuentes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var preguntasFrecuentesChatBot = await _preguntasFrecuentesChatBotRepository.GetAllAsync();
                return Ok(preguntasFrecuentesChatBot);
            }
            catch (Exception)
            {
                return BadRequest(false); // Ocurrió un error, devuelve false
            }
        }

        // Get: obtener una pregunta frecuente por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var preguntasFrecuentesChatBot = await _preguntasFrecuentesChatBotRepository.GetByIdAsync(id);
                if (preguntasFrecuentesChatBot == null)
                {
                    return NotFound(); // Devuelve 404 si no se encuentra la pregunta frecuente
                }
                return Ok(preguntasFrecuentesChatBot);
            }
            catch (Exception)
            {
                return BadRequest(false); // Ocurrió un error, devuelve false
            }
        }

        //GET: obtener una pregunta frecuente por pregunta
        [HttpGet("pregunta/{pregunta}")]
        public async Task<IActionResult> GetByPregunta(string pregunta)
        {
            try
            {
                var preguntasFrecuentesChatBot = await _preguntasFrecuentesChatBotRepository.GetByPreguntaAsync(pregunta);
                if (preguntasFrecuentesChatBot == null)
                {
                    return NotFound(); // Devuelve 404 si no se encuentra la pregunta frecuente
                }
                return Ok(preguntasFrecuentesChatBot);
            }
            catch (Exception)
            {
                return BadRequest(false); // Ocurrió un error, devuelve false
            }
        }
        // PUT: actualizar una pregunta frecuente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PreguntasFrecuentesChatBot preguntasFrecuentesChatBot)
        {
            if (preguntasFrecuentesChatBot == null || id != preguntasFrecuentesChatBot.IdPregunta)
            {
                return BadRequest("Datos inválidos");
            }

            var existente = await _preguntasFrecuentesChatBotRepository.GetByIdAsync(id);
            if (existente == null)
            {
                return NotFound("No se encontró el registro");
            }

            try
            {
                // Aquí puedes actualizar las propiedades necesarias (si quieres)
                // o simplemente pasar el objeto completo:
                await _preguntasFrecuentesChatBotRepository.UpdateAsync(preguntasFrecuentesChatBot);
                return Ok(true); // o NoContent() si prefieres no devolver nada
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, "Error al actualizar: " + ex.Message);
            }
        }

        //DELETE: eliminar una pregunta frecuente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existente = await _preguntasFrecuentesChatBotRepository.GetByIdAsync(id);
                if (existente == null)
                {
                    return NotFound("No se encontró el registro");
                }
                await _preguntasFrecuentesChatBotRepository.DeleteAsync(id);
                return Ok(true); // o NoContent() si prefieres no devolver nada
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, "Error al eliminar: " + ex.Message);
            }
        }



    }
}
