using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotRepository
    {
        Task<IEnumerable<CalificacionChatBot>> GetAllAsync();
        Task<CalificacionChatBot?> GetByIdAsync(int id);
        Task<int> CreateAsync(CalificacionChatBot entity);
        Task<bool> UpdateAsync(CalificacionChatBot entity);
        Task<bool> DeleteAsync(int id);
    }
}
