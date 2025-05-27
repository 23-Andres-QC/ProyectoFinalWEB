using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPresenciaEnListasRepository
    {
        Task<List<PresenciaEnListas>> GetAllAsync();
        Task<PresenciaEnListas?> GetByIdAsync(int id);
        Task<int> CreateAsync(PresenciaEnListas presencia);
        Task UpdateAsync(PresenciaEnListas presencia);
        Task DeleteAsync(int id);
    }
}