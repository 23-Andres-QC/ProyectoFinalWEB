using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPreguntasFrecuentesChatBotRepository
    {
        Task<IEnumerable<PreguntasFrecuentesChatBot>> GetAllAsync();
        Task<PreguntasFrecuentesChatBot?> GetByIdAsync(int id);
        Task<int> CreateAsync(PreguntasFrecuentesChatBot entity);
        Task<bool> UpdateAsync(PreguntasFrecuentesChatBot entity);
        Task<bool> DeleteAsync(int id);
    }
}
