using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotRepository
    {
        Task CreateAsync(CalificacionChatBot calificacionChatBot);

        Task<List<CalificacionChatBot>> GetAllAsync();

    }
}