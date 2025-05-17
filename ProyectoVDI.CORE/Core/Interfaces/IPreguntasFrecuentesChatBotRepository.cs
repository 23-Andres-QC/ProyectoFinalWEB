using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotRepository
    {
        Task CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);
        Task<List<PreguntasFrecuentesChatBot>> GetAllAsync();
        Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);
        Task DeleteAsync(int id);
        Task<PreguntasFrecuentesChatBot> GetByIdAsync(int id);
        Task<PreguntasFrecuentesChatBot> GetByPreguntaAsync(string pregunta);
        
    }
}