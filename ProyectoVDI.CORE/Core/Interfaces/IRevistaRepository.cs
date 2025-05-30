using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task<List<Revista>> GetAllAsync();
        Task<Revista?> GetByIdAsync(int id);
        Task<int> CreateAsync(Revista revista);
        Task UpdateAsync(Revista revista);
        Task DeleteAsync(int id);

        Task<List<Revista>> GetRevistasWithAllJoinsAsync();
    }
}