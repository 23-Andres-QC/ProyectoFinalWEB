using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotService
    {
        Task<IEnumerable<CalificacionChatBotListDTO>> GetAllAsync();
      
        Task <IEnumerable<CalificacionChatBotListDTO>> GetByIdListAsync(int idUsuario);
        Task<IEnumerable<CalificacionChatBotDetailDTO>> GetAllDetailAsync();
        Task<int> CreateAsync(CalificacionChatBotCreateDTO dto);
        Task<bool> UpdateAsync(CalificacionChatBotUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
