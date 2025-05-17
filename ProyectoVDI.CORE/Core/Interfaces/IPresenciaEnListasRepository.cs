using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    internal interface IPresenciaEnListasRepository
    {
        Task AddPresenciaEnListasAsync(PresenciaEnListas presencia);
        Task DeletePresenciaEnListasAsync(int id);
        Task<IEnumerable<PresenciaEnListas>> GetAllPresenciaEnListasAsync();
        Task<PresenciaEnListas?> GetPresenciaEnListasById(int id);
        Task UpdatePresenciaEnListasAsync(PresenciaEnListas presencia);
    }
}