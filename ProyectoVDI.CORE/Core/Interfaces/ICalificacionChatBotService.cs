using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<int> CreateCalificacionChatBot(CalificacionChatBotCreateDTO dto);
        Task DeleteCalificacionChatBot(int id);
        Task<CalificacionChatBotDTO?> GetCalificacionChatBotById(int id);
        Task<IEnumerable<CalificacionChatBotListDTO>> GetCalificacionChatBots();
        Task<bool> UpdateCalificacionChatBot(CalificacionChatBotUpdateDTO dto);
    }
}
