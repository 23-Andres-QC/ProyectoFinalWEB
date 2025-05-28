using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotRepository
    {
        Task<int> CreateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);
        Task<List<PreguntasFrecuentesChatBot>> GetAllAsync();
        Task<PreguntasFrecuentesChatBot?> GetByIdAsync(int id);
        Task UpdateAsync(PreguntasFrecuentesChatBot preguntasFrecuentesChatBot);

        Task UpdateEstadoAsync(int id, string estado);
        Task DeleteAsync(int id);
    }
}