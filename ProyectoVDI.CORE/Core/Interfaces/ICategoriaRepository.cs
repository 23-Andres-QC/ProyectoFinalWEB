using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<int> CreateAsync(Categorias categoria);
        Task DeleteAsync(int id);
        Task<List<Categorias>> GetAllAsync();
        Task<Categorias> GetByIdAsync(int id);
        Task UpdateAsync(Categorias categoria);
    }
}