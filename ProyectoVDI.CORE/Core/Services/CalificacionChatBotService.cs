using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<CalificacionChatBotListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<CalificacionChatBotListDTO>();
            foreach (var item in list)
            {
                result.Add(new CalificacionChatBotListDTO
                {
                    IdFeedback = item.IdFeedback,
                    IdUsuario = item.IdUsuario,
                    Calificacion = item.Calificacion,
                    Fecha = item.Fecha
                });
            }
            return result;
        }

        public async Task<CalificacionChatBotDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new CalificacionChatBotDetailDTO
            {
                IdFeedback = item.IdFeedback,
                IdUsuario = item.IdUsuario,
                Calificacion = item.Calificacion,
                Fecha = item.Fecha
            };
        }

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

        public async Task<bool> UpdateAsync(CalificacionChatBotUpdateDTO dto)
        {
            var entity = new CalificacionChatBot
            {
                IdFeedback = dto.IdFeedback,
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
