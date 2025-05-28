using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        Task<int> CreateAsync(createPreguntasFrecuentesChatBotDTO preguntasFrecuentesChatBotDto);
        Task<List<listPreguntasFrecuentesChatBotDTO>> GetAllAsync();
        Task <GetByIdPreguntasFrecuentesChatBotDTO> GetByIdAsync(int id);
        Task UpdateAsync(updatePreguntasFrecuentesChatBotDTO preguntasFrecuentesChatBotDto);
        Task UpdateEstadoAsync(updateEstadoPreguntasFrecuentesChatBotDTO updateEstadoDto);
        Task DeleteAsync(int id);



    }
}
