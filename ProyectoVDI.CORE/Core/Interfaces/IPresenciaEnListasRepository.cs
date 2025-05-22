using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPresenciaEnListasRepository
    {
        Task<int> CreateAsync(PresenciaEnListas presencia);
        Task DeleteAsync(int id);
        Task<List<PresenciaEnListas>> GetAllAsync();
        Task<PresenciaEnListas> GetByIdAsync(int id);
        Task UpdateAsync(PresenciaEnListas presencia);
    }
}