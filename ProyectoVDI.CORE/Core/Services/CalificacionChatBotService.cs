using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class CalificacionChatBotService : ICalificacionChatBotService
    {
        private readonly ICalificacionChatBotRepository _repository;
        public CalificacionChatBotService(ICalificacionChatBotRepository repository)
        {
            _repository = repository;
        }

        // obtener solo calificaciones de chatbots

        public async Task<IEnumerable<CalificacionChatBotListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<CalificacionChatBotListDTO>();
            foreach (var item in list)
            {
                result.Add(new CalificacionChatBotListDTO
                {
                    IdUsuario = item.IdUsuario,
                    Calificacion = item.Calificacion,
                    
                });
            }
            return result;
        }
        // obtener calificacion por id 
        public async Task<IEnumerable<CalificacionChatBotListDTO>> GetByIdListAsync(int idUsuario)
        {
            var list = await _repository.GetAllAsync();
            var result = new List<CalificacionChatBotListDTO>();
            foreach (var item in list)
            {
                if (item.IdUsuario == idUsuario)
                {
                    result.Add(new CalificacionChatBotListDTO
                    {
                        IdUsuario = item.IdUsuario,
                        Calificacion = item.Calificacion,
                    });
                }
            }
            return result;

        }




        // obtener calificacion del chat bot con todo detalle

        public async Task<IEnumerable<CalificacionChatBotDetailDTO>> GetAllDetailAsync()
        {
            var item = await _repository.GetAllAsync();
            var result = new List<CalificacionChatBotDetailDTO>();
            foreach (var entity in item)
            {
                result.Add(new CalificacionChatBotDetailDTO
                {
                    IdFeedback = entity.IdFeedback,
                    IdUsuario = entity.IdUsuario,
                    Calificacion = entity.Calificacion,
                    Fecha = entity.Fecha
                });
            }
            return result;

        }

        // crear calificacion del chat bot

        public async Task<int> CreateAsync(CalificacionChatBotCreateDTO dto)
        {
            var entity = new CalificacionChatBot
            {
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion,
                Fecha = System.DateTime.Now
            };
            return await _repository.CreateAsync(entity);
        }

        // actualizar calificacion del chat bot
        public async Task<bool> UpdateAsync(CalificacionChatBotUpdateDTO dto)
        {
            var entity = new CalificacionChatBot
            {
                IdFeedback = dto.IdFeedback,
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion,
                Fecha = System.DateTime.Now

            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
