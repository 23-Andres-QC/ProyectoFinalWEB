using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        Task<int> CreatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotCreateDTO dto);
        Task DeletePreguntasFrecuentesChatBot(int id);
        Task<PreguntasFrecuentesChatBotDTO?> GetPreguntasFrecuentesChatBotById(int id);
        Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetPreguntasFrecuentesChatBot();
        Task<bool> UpdatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotUpdateDTO dto);
    }
}
