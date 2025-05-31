using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<IEnumerable<Categorias>> GetAllAsync();
        Task<Categorias?> GetByIdAsync(int id);
        Task<int> CreateAsync(Categorias entity);
        Task<bool> UpdateAsync(Categorias entity);
        Task<bool> DeleteAsync(int id);
    }
}
