using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        int Create(Categorias categoria);
        Task<int> CreateAsync(Categorias categoria);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Categorias> GetAll();
        Task<IEnumerable<Categorias>> GetAllAsync();
        Categorias GetById(int id);
        Task<Categorias> GetByIdAsync(int id);
        bool Update(Categorias categoria);
        Task<bool> UpdateAsync(Categorias categoria);
    }
}