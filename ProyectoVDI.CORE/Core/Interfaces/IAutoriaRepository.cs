using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IAutoriaRepository
    {
        Task<List<Autoria>> GetAllAsync();
        Task<Autoria?> GetByIdAsync(int id);
        Task<int> CreateAsync(Autoria autoria);
        Task UpdateAsync(Autoria autoria);
        Task DeleteAsync(int id);
    }
}