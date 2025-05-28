using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroISSNRepository
    {
        Task<bool> CreateAsync(RegistroIssn registroISSN);
        Task<List<RegistroIssn>> GetAllAsync();
        Task<RegistroIssn?> GetByIdAsync(int id);
        Task<List<RegistroIssn>> GetByFechaAsync(DateOnly fecha);

        Task<bool> UpdateAsync(RegistroIssn registroISSN);
        Task<bool> DeleteAsync(int id);
    }
}