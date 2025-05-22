using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IAutoriaRepository
    {
        Task<int> CreateAsync(Autoria autoria);
        Task DeleteAsync(int id);
        Task<List<Autoria>> GetAllAsync();
        Task<Autoria> GetByIdAsync(int id);
        Task UpdateAsync(Autoria autoria);
    }
}