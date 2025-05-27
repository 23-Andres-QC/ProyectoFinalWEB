using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICalificacionChatBotRepository
    {
        Task<int> CreateAsync(CalificacionChatBot calificacionChatBot);
        Task<List<CalificacionChatBot>> GetAllAsync();
        Task<CalificacionChatBot?> GetByIdAsync(int id);
        Task UpdateAsync(CalificacionChatBot calificacionChatBot);
        Task DeleteAsync(int id);
    }
}