using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<IEnumerable<CalificacionChatBotListDTO>> GetCalificacionChatBots();

        //TODO DE LAS CALIFICAIONES
        Task<IEnumerable<CalificacionChatBotDTO>> GetCalificacionChatBot();
        Task<CalificacionChatBotDTO?> GetCalificacionChatBotById(int id);
        Task<int> CreateCalificacionChatBot(CalificacionChatBotCreateDTO dto);
        Task<bool> UpdateCalificacionChatBot(CalificacionChatBotUpdateDTO dto);
        
        Task DeleteCalificacionChatBot(int id);
    }
}
