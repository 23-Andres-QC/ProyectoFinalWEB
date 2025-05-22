using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IAutoriaRepository
    {
        int Create(Autoria item);
        Task<int> CreateAsync(Autoria item);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Autoria> GetAll();
        Task<IEnumerable<Autoria>> GetAllAsync();
        Autoria GetById(int id);
        Task<Autoria> GetByIdAsync(int id);
        bool Update(Autoria item);
        Task<bool> UpdateAsync(Autoria item);
    }
}