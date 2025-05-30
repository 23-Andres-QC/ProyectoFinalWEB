using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    /*
     * Interfaz para el repositorio de Profesores.
     * Define las operaciones CRUD y navegación de entidades relacionadas.
     */
    public interface IProfesoresRepository
    {
        Task<List<Profesores>> GetAllAsync();
        Task<Profesores?> GetByIdAsync(int id);
        Task<int> CreateAsync(Profesores profesor);
        Task UpdateAsync(Profesores profesor);
        Task DeleteAsync(int id);

    }
}