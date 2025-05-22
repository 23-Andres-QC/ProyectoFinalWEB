using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotRepository
    {
        Task CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);
        Task DeleteAsync(int id);
        Task<List<PreguntasFrecuentesChatBot>> GetAllAsync();
        Task<PreguntasFrecuentesChatBot> GetByIdAsync(int id);
        Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);
    }
}