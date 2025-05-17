using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistasIndexacionRepository
    {
        int Create(RevistaIndexacion item);
        Task<int> CreateAsync(RevistaIndexacion item);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        IEnumerable<RevistaIndexacion> GetAll();
        Task<IEnumerable<RevistaIndexacion>> GetAllAsync();
        RevistaIndexacion GetById(int id);
        Task<RevistaIndexacion> GetByIdAsync(int id);
        bool Update(RevistaIndexacion item);
        Task<bool> UpdateAsync(RevistaIndexacion item);
    }
}