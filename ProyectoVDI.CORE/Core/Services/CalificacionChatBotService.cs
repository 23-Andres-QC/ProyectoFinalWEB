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

        public async Task<IEnumerable<CalificacionChatBotListDTO>> GetCalificacionChatBots()
        {
            var calificaciones = await _repository.GetAllAsync();
            var list = new List<CalificacionChatBotListDTO>();
            foreach (var cal in calificaciones)
            {
                list.Add(new CalificacionChatBotListDTO
                {
                    IdFeedback = cal.IdFeedback,
                    IdUsuario = cal.IdUsuario
                });
            }
            return list;
        }

        public async Task<CalificacionChatBotDTO?> GetCalificacionChatBotById(int id)
        {
            var cal = await _repository.GetByIdAsync(id);
            if (cal == null) return null;
            return new CalificacionChatBotDTO
            {
                IdFeedback = cal.IdFeedback,
                IdUsuario = cal.IdUsuario,
                Calificacion = cal.Calificacion,
                FechaHora = cal.FechaHora
            };
        }

        public async Task<int> CreateCalificacionChatBot(CalificacionChatBotCreateDTO dto)
        {
            var cal = new CalificacionChatBot
            {
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion,
                FechaHora = DateTime.Now // Assuming FechaHora is set to current time on creation
            };
            return await _repository.CreateAsync(cal);
        }

        public async Task<bool> UpdateCalificacionChatBot(CalificacionChatBotUpdateDTO dto)
        {
            var cal = await _repository.GetByIdAsync(dto.IdFeedback);
            if (cal == null) return false;
            cal.IdUsuario = dto.IdUsuario;
            cal.Calificacion = dto.Calificacion;
            cal.FechaHora = DateTime.Now;
            await _repository.UpdateAsync(cal);
            return true;
        }

        public async Task DeleteCalificacionChatBot(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
