using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotRepository
    {
        Task CreateAsync(CalificacionChatBot calificacionChatBot);
        Task DeleteAsync(int id);
        Task<List<CalificacionChatBot>> GetAllAsync();
        Task<CalificacionChatBot> GetByIdAsync(int id);
        Task UpdateAsync(CalificacionChatBot calificacionChatBot);
    }
}