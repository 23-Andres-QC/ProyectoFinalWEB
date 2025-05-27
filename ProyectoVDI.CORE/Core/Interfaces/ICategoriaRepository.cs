using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categorias>> GetAllAsync();
        Task<Categorias?> GetByIdAsync(int id);
        Task<int> CreateAsync(Categorias categoria);
        Task UpdateAsync(Categorias categoria);
        Task DeleteAsync(int id);
    }
}