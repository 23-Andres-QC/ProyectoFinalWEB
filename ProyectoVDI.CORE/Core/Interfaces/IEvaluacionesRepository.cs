using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEvaluacionesRepository
    {
        Task AddEvaluacionAsync(Evaluaciones evaluacion);
        Task DeleteEvaluacionAsync(int id);
        Task<IEnumerable<Evaluaciones>> GetAllEvaluacionesAsync();
        Task<Evaluaciones?> GetEvaluacionById(int id);
        Task<IEnumerable<Evaluaciones>> GetEvaluacionesByOrdenAsync(int idRevista);
        Task UpdateEvaluacionAsync(Evaluaciones evaluacion);
    }
}