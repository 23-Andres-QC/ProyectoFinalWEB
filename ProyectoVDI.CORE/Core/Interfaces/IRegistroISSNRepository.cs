using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroISSNRepository
    {
        Task<int> CreateAsync(RegistroIssn registroISSN);
        Task<List<RegistroIssn>> GetAllAsync();
        Task<RegistroIssn?> GetByIdAsync(int id);
        Task UpdateAsync(RegistroIssn registroISSN);
        Task DeleteAsync(int id);
    }
}