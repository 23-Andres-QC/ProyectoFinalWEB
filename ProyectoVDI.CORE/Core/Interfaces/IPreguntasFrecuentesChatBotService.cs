using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetAllAsync();
        Task<PreguntasFrecuentesChatBotDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(PreguntasFrecuentesChatBotCreateDTO dto);
        Task<bool> UpdateAsync(PreguntasFrecuentesChatBotUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
