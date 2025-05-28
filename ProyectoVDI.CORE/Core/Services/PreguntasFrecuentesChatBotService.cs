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
        /// Crear nueva pregunta frecuente

        public async Task<int> CreateAsync(createPreguntasFrecuentesChatBotDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                IdUsuario = dto.IdUsuario,
                Estado = "Activo", // Asignar estado por defecto 
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now)

            };
            return await _repository.CreateAsync(entity);
        }

        /// Obtener todas las preguntas frecuentes
        public async Task<List<listPreguntasFrecuentesChatBotDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.ConvertAll(e => new listPreguntasFrecuentesChatBotDTO
            {
                IdPregunta = e.IdPregunta,
                Pregunta = e.Pregunta,
                Respuesta = e.Respuesta,
                Categoria = e.Categoria,
                Estado = e.Estado,
                IdUsuario = e.IdUsuario,
                FechaCreacion = e.FechaCreacion
            });
        }

        // obtener pregunta frecuente por id
        public async Task<GetByIdPreguntasFrecuentesChatBotDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new GetByIdPreguntasFrecuentesChatBotDTO
            {
                Pregunta = entity.Pregunta,
                Respuesta = entity.Respuesta
            };
        }

        /// Actualizar una pregunta frecuente existente
        public async Task UpdateAsync(updatePreguntasFrecuentesChatBotDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                IdPregunta = dto.IdPregunta,
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                IdUsuario = dto.IdUsuario,

                Estado = "Activo",
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now)

            };
            await _repository.UpdateAsync(entity);
        }

        /// Actualizar el estado de una pregunta frecuente
        public async Task UpdateEstadoAsync(updateEstadoPreguntasFrecuentesChatBotDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.IdPregunta);
            if (entity == null)
            {
                throw new InvalidOperationException($"No se encontró la pregunta frecuente con ID {dto.IdPregunta} para actualizar el estado.");
            }
            entity.Estado = dto.Estado;
            await _repository.UpdateAsync(entity);
        }


        /// Eliminar una pregunta frecuente por ID
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException($"No se encontró la pregunta frecuente con ID {id} para eliminar.");
            }
            await _repository.DeleteAsync(id);


        }
    }
}
