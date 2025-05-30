using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task<List<Revista>> GetAllAsync();
        Task<List<Revista>> GetAllAlgunasAsync(); // Agregado para simple list
        Task<Revista?> GetByIdAsync(int id);
        Task<int> CreateAsync(Revista revista);
        Task<int> UpdateAsync(Revista revista);
        Task<string> DeleteAsync(int id);
    }
}