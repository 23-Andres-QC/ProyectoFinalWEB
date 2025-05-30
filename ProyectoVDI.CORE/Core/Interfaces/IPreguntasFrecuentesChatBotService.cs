using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotService
    {
        //todas las preguntas frecuentes para el administrador
        Task<IEnumerable<PreguntasFrecuentesChatBotDTO>> GetAllPreguntasFrecuentesChatBot();

        // obtener todas las preguntas para el chat bot
        Task<IEnumerable<PreguntasFrecuentesChatBotListDTO>> GetPreguntasFrecuentesChatBot();

        // obtener una respuesta frecuente del chat bot por id
        Task<PreguntasFrecuentesChatBotResponseDTO?> GetRespuestaPreguntasFrecuentesChatBotById(int id);
        Task<PreguntasFrecuentesChatBotDTO?> GetPreguntasFrecuentesChatBotById(int id);
        Task<int> CreatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotCreateDTO dto);
        Task<bool> UpdatePreguntasFrecuentesChatBot(PreguntasFrecuentesChatBotUpdateDTO dto);
        // actualizar el estado de una pregunta frecuente del chat bot
        Task<bool> UpdateEstadoPreguntasFrecuentesChatBot(UpdateEstadoPreguntasFrecuentesChatBotDTO dto);
        Task DeletePreguntasFrecuentesChatBot(int id);
       
    }
}
