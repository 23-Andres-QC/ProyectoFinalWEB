using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresRepository
    {
        Task<List<Profesores>> GetAllAsync();
        Task<Profesores?> GetByIdAsync(int id); // Debe incluir la navegación de usuarios asociados
        Task<int> CreateAsync(Profesores profesor);
        Task UpdateAsync(Profesores profesor);
        Task DeleteAsync(int id);
    }
}