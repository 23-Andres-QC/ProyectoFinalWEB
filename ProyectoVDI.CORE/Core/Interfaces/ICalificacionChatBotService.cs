using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<IEnumerable<CalificacionChatBotListDTO>> GetAllAsync();
        Task<CalificacionChatBotDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CalificacionChatBotCreateDTO dto);
        Task<bool> UpdateAsync(CalificacionChatBotUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
