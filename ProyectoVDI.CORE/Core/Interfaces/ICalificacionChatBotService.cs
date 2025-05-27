using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<int> CreateAsync(CreateCalificacionChatBotDTO dto);
        Task<IEnumerable<ListCalificacionChatBotDTO>> GetAllAsync();
    }
}