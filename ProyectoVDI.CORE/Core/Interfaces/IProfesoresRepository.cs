using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresRepository
    {
        Task CreateAsync(Profesores profesor);
        Task DeleteAsync(int id);
        Task<List<Profesores>> GetAllAsync();
        Task<Profesores> GetByIdAsync(int id);
        Task UpdateAsync(Profesores profesor);
    }
}