using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistasIndexacionRepository
    {
        Task<int> CreateAsync(RevistaIndexacion item);
        Task DeleteAsync(int id);
        Task<List<RevistaIndexacion>> GetAllAsync();
        Task<RevistaIndexacion> GetByIdAsync(int id);
        Task UpdateAsync(RevistaIndexacion item);
    }
}