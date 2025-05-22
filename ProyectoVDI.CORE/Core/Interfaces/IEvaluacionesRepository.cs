using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEvaluacionesRepository
    {
        Task CreateAsync(Evaluaciones evaluacion);
        Task DeleteAsync(int id);
        Task<List<Evaluaciones>> GetAllAsync();
        Task<Evaluaciones> GetByIdAsync(int id);
        Task UpdateAsync(Evaluaciones evaluacion);
    }
}