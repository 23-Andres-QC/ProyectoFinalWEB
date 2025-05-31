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

        public async Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<PreguntasFrecuentesChatBotListDTO>();
            foreach (var item in list)
            {
                result.Add(new PreguntasFrecuentesChatBotListDTO
                {
                    IdPregunta = item.IdPregunta,
                    Pregunta = item.Pregunta,
                    Categoria = item.Categoria,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<PreguntasFrecuentesChatBotDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new PreguntasFrecuentesChatBotDetailDTO
            {
                IdPregunta = item.IdPregunta,
                Pregunta = item.Pregunta,
                Respuesta = item.Respuesta,
                Categoria = item.Categoria,
                Estado = item.Estado,
                IdUsuario = item.IdUsuario,
                FechaCreacion = item.FechaCreacion
            };
        }

        public async Task<int> CreateAsync(PreguntasFrecuentesChatBotCreateDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                Estado = "Activo",
                IdUsuario = dto.IdUsuario,
                FechaCreacion = System.DateTime.Now
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(PreguntasFrecuentesChatBotUpdateDTO dto)
        {
            var entity = new PreguntasFrecuentesChatBot
            {
                IdPregunta = dto.IdPregunta,
                Pregunta = dto.Pregunta,
                Respuesta = dto.Respuesta,
                Categoria = dto.Categoria,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
