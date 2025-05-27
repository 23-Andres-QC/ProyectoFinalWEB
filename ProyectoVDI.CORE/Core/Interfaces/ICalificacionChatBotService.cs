using ProyectoVDI.CORE.Core.DTOs;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<int> CreateAsync(CreateCalificacionChatBotDTO dto);
        Task<bool> UpdateAsync(UpdateCalificacionChatBotDTO dto);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ListCalificacionChatBotDTO>> GetAllAsync();
    }
}