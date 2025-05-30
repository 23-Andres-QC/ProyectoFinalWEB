using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class PreguntasFrecuentesChatBotService : IPreguntasFrecuentesChatBotService
    {
        private readonly IPreguntasFrecuentesChatBotRepository _repository;

        public PreguntasFrecuentesChatBotService(IPreguntasFrecuentesChatBotRepository repository)
        {
            _repository = repository;


        }

        // preguntas frecuentas para el Administrador

        public async Task<IEnumerable<PreguntasFrecuentesChatBotDTO>> GetAllPreguntasFrecuentesChatBot()
        {
            var preguntas = await _repository.GetAllAsync();
            var list = new List<PreguntasFrecuentesChatBotDTO>();
            foreach (var pregunta in preguntas)
            {
                list.Add(new PreguntasFrecuentesChatBotDTO
                {
                    IdPregunta = pregunta.IdPregunta,
                    Pregunta = pregunta.Pregunta,
                    Respuesta = pregunta.Respuesta,
                    Categoria = pregunta.Categoria,
                    Estado = pregunta.Estado,
                    IdUsuario = pregunta.IdUsuario,
                    FechaCreacion = pregunta.FechaCreacion
                });
            }
            return list;
        }

        // obtener todas las preguntas frecuentes para el chat bot
        public async Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetPreguntasFrecuentesChatBot()
        {
            var preguntas = await _repository.GetAllAsync();
            var list = new List<PreguntasFrecuentesChatBotListDTO>();
            foreach (var pregunta in preguntas)
            {
                list.Add(new PreguntasFrecuentesChatBotListDTO
                {
                    
                    Pregunta = pregunta.Pregunta,
                    Respuesta = pregunta.Respuesta

                });
            }
            return list;
        }


        // obtener respuesta de una pregunta frecuente del chat bot por id
        public async Task<PreguntasFrecuentesChatBotDTO?> GetPreguntasFrecuentesChatBotById(int id)
        {
            var pregunta = await _repository.GetByIdAsync(id);
            if (pregunta == null) return null;
            return new PreguntasFrecuentesChatBotDTO
            {
                IdPregunta = pregunta.IdPregunta,
                Pregunta = pregunta.Pregunta,
                Respuesta = pregunta.Respuesta,
                Categoria = pregunta.Categoria,
                Estado = pregunta.Estado,
                IdUsuario = pregunta.IdUsuario,
                FechaCreacion = pregunta.FechaCreacion
            };
        }

        // obtener respuesta de una pregunta frecuente del chat bot por id
        public async Task<PreguntasFrecuentesChatBotResponseDTO?> GetRespuestaPreguntasFrecuentesChatBotById(int id)
        {
            var pregunta = await _repository.GetByIdAsync(id);
            if (pregunta == null) return null;
            return new PreguntasFrecuentesChatBotResponseDTO
            {
                Respuesta = pregunta.Respuesta
            };
        }



        // crear una pregunta frecuente del chat bot

        public async Task<int> CreatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotCreateDTO dto)
        {
            var pregunta = new PreguntasFrecuentesChatBot
            {
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                Estado = "Activo",
                IdUsuario = dto.IdUsuario,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now)
            };
            await _repository.CreateAsync(pregunta);
            return pregunta.IdPregunta;
        }


        // actualizar una pregunta frecuente del chat bot
        public async Task<bool> UpdatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            var pregunta = await _repository.GetByIdAsync(dto.IdPregunta);
            if (pregunta == null) return false;
            pregunta.Pregunta = dto.Pregunta;
            pregunta.Respuesta = dto.Respuesta;
            pregunta.Categoria = dto.Categoria;
            pregunta.Estado = dto.Estado;
            pregunta.IdUsuario = dto.IdUsuario;
            await _repository.UpdateAsync(pregunta);
            return true;
        }

        // actualizar el estado de una pregunta frecuente del chat bot
        public async Task<bool> UpdateEstadoPreguntasFrecuentesChatBot(UpdateEstadoPreguntasFrecuentesChatBotDTO dto)
        {
            var pregunta = await _repository.GetByIdAsync(dto.IdPregunta);
            if (pregunta == null) return false;
            pregunta.Estado = dto.Estado;
            await _repository.UpdateAsync(pregunta);
            return true;
        }

        public async Task DeletePreguntasFrecuentesChatBot(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
