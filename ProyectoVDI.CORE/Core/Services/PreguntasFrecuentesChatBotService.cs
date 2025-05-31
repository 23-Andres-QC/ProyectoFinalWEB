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

        // Obtener preguntas y respuestas frecuentes del chatbot
        // Listar todas las preguntas frecuentes del chatbot
        public Task<IEnumerable<GetAllPreguntasFrecuentesDTO>> GetAllPreguntasAsync()
        {
            var list = _repository.GetAllAsync();
            var result = new List<GetAllPreguntasFrecuentesDTO>();
            foreach (var item in list.Result)
            {
                result.Add(new GetAllPreguntasFrecuentesDTO
                {
                    IdPregunta = item.IdPregunta,
                    Pregunta = item.Pregunta,
                    
                });
            }
            return Task.FromResult<IEnumerable<GetAllPreguntasFrecuentesDTO>>(result);
        }


        // Obtener una pregunta frecuente del chatbot por ID
        public async Task<PreguntasFrecuentesChatBotDTObyId?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new PreguntasFrecuentesChatBotDTObyId
            {                                
                Respuesta = item.Respuesta
               
            };
        }



        // Obtener todas las preguntas frecuentes del chatbot con detalles
        public async Task<IEnumerable<PreguntasFrecuentesChatBotDetailDTO>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            var result = new List<PreguntasFrecuentesChatBotDetailDTO>();
            foreach (var item in items)
            {
                result.Add(new PreguntasFrecuentesChatBotDetailDTO
                {
                    IdPregunta = item.IdPregunta,
                    Pregunta = item.Pregunta,
                    Respuesta = item.Respuesta,
                    Categoria = item.Categoria,
                    Estado = item.Estado,
                    IdUsuario = item.IdUsuario,
                    FechaCreacion = item.FechaCreacion
                });
            }
            return result;
        }





     
        // Crear una nueva pregunta frecuente del chatbot

        public async Task<int> CreateAsync(PreguntasFrecuentesChatBotCreateDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                Estado = "Activo",
                IdUsuario = dto.IdUsuario,
                FechaCreacion = DateTime.Now
            };
            return await _repository.CreateAsync(entity);
        }

        // Actualizar una pregunta frecuente del chatbot y sus detalles
        public async Task<bool> UpdateAsync(PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            var currentEntity = await _repository.GetByIdAsync(dto.IdPregunta);
            if (currentEntity == null) return false;

            // Actualizar solo si el campo no es nulo
            currentEntity.Pregunta = dto.Pregunta ?? currentEntity.Pregunta;
            currentEntity.Respuesta = dto.Respuesta ?? currentEntity.Respuesta;
            currentEntity.Categoria = dto.Categoria ?? currentEntity.Categoria;
            currentEntity.Estado = dto.Estado ?? currentEntity.Estado;
                       

            return await _repository.UpdateAsync(currentEntity);
        }

        //Actualizar el estado de una pregunta frecuente del chatbot
        // api/
        public async Task<bool> UpdateEstadoAsync(ActualizarEstadoPreguntaFrecuenteDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                IdPregunta = dto.IdPregunta,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }
        // Eliminar una pregunta frecuente del chatbot

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
