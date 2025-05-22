using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroISSNRepository
    {
        Task CreateAsync(DetRegistroIssn detalle);
        Task DeleteAsync(int idRegistroIssn, int idRevista);
        Task<List<DetRegistroIssn>> GetAllAsync();
        Task<List<DetRegistroIssn>> GetByRegistroIdAsync(int idRegistroIssn);
        Task UpdateAsync(DetRegistroIssn detalle);
    }
}