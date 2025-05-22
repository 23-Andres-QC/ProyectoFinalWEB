using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroISSNRepository
    {
        Task CreateAsync(RegistroIssn registroISSN);
        Task DeleteAsync(int id);
        Task<List<RegistroIssn>> GetAllAsync();
        Task<RegistroIssn> GetByIdAsync(int id);
        Task UpdateAsync(RegistroIssn registroISSN);
    }
}