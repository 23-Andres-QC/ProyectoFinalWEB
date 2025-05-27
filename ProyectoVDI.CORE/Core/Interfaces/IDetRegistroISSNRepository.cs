using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroISSNRepository
    {
        Task<(int? IdRegistroIssn, int? IdRevista)> CreateAsync(DetRegistroIssn detalle);
        Task<List<DetRegistroIssn>> GetAllAsync();
        Task<List<DetRegistroIssn>> GetByRegistroIdAsync(int idRegistroIssn);
        Task UpdateAsync(DetRegistroIssn detalle);
        Task DeleteAsync(int idRegistroIssn, int idRevista);
    }
}