using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistasIndexacionRepository
    {
        Task<List<RevistaIndexacion>> GetAllAsync();
        Task<RevistaIndexacion?> GetByIdAsync(int id);
        Task<int> CreateAsync(RevistaIndexacion item);
        Task UpdateAsync(RevistaIndexacion item);
        Task DeleteAsync(int id);
    }
}