using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        Task<IEnumerable<GetAllPreguntasFrecuentesDTO>> GetAllPreguntasAsync();
        Task<PreguntasFrecuentesChatBotDTObyId?> GetByIdAsync(int id);
        Task<IEnumerable<PreguntasFrecuentesChatBotDetailDTO>> GetAllAsync();
        Task<int> CreateAsync(PreguntasFrecuentesChatBotCreateDTO dto);
        Task<bool> UpdateAsync(PreguntasFrecuentesChatBotUpdateDTO dto);
        Task<bool> UpdateEstadoAsync(ActualizarEstadoPreguntaFrecuenteDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
