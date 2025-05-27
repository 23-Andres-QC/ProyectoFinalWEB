using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;

namespace ProyectoVDI.CORE.Core.Services
{
    public class CalificacionChatBotService : ICalificacionChatBotService
    {
        private readonly ICalificacionChatBotRepository _repository;

        public CalificacionChatBotService(ICalificacionChatBotRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateCalificacionChatBotDTO dto)
        {
            var calificacion = new CalificacionChatBot
            {
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion,
                FechaHora = DateTime.Now
            };

            await _repository.CreateAsync(calificacion);
            return calificacion.IdFeedback;
        }

        public async Task<IEnumerable<ListCalificacionChatBotDTO>> GetAllAsync()
        {
            var calificaciones = await _repository.GetAllAsync();
            var list = new List<ListCalificacionChatBotDTO>();

            foreach (var cal in calificaciones)
            {
                list.Add(new ListCalificacionChatBotDTO
                {
                    IdFeedback = cal.IdFeedback,
                    IdUsuario = cal.IdUsuario,
                    Calificacion = cal.Calificacion,
                    FechaHora = cal.FechaHora
                });
            }

            return list;
        }
    } // <--- ESTA ES LA QUE TE FALTA
}
