using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetPreguntasFrecuentesChatBot();
        Task<PreguntasFrecuentesChatBotDTO?> GetPreguntasFrecuentesChatBotById(int id);
        Task<int> CreatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotCreateDTO dto);
        Task<bool> UpdatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotUpdateDTO dto);
        Task DeletePreguntasFrecuentesChatBot(int id);
    }
}
