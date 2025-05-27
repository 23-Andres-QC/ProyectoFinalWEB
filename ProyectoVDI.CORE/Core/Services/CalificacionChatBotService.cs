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

        // crear una nueva calificación de chatbots de forma dto
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

        // actualizar una calificación de chatbots de forma dto
        public async Task<bool> UpdateAsync(UpdateCalificacionChatBotDTO dto)
        {
            var calificacion = new CalificacionChatBot
            {
                IdFeedback = dto.IdFeedback,
                IdUsuario = dto.IdUsuario,
                Calificacion = dto.Calificacion
            };

            await _repository.UpdateAsync(calificacion);
            return true;
        }

        // eliminar una calificación de chatbots por ID de forma dto
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception)
            {
                return false; // Si ocurre un error, devuelve false
            }
        }



        // obtener todas las calificaciones de chatbots de forma dto
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
    }
}