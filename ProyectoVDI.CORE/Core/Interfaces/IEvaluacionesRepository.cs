using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEvaluacionesRepository
    {
        Task<List<Evaluaciones>> GetAllAsync();
        Task<Evaluaciones?> GetByIdAsync(int id);
        Task<int> CreateAsync(Evaluaciones evaluacion);
        Task UpdateAsync(Evaluaciones evaluacion);
        Task DeleteAsync(int id);
    }
}