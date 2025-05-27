using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEditorialRepository
    {
        Task<List<Editorial>> GetAllAsync();
        Task<Editorial?> GetByIdAsync(int id);
        Task<int> CreateAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(int id);
    }
}