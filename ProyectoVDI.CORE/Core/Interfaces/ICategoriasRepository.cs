using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    // Interfaz para el repositorio de Categorias
    public interface ICategoriasRepository
    {
        // Obtiene todas las categorias
        Task<IEnumerable<Categorias>> GetAllAsync();
        // Obtiene una categoria por su ID
        Task<Categorias?> GetByIdAsync(int id);
        // Crea una nueva categoria
        Task<int> CreateAsync(Categorias entity);
        // Actualiza una categoria existente
        Task<bool> UpdateAsync(Categorias entity);
        // Elimina (desactiva) una categoria por su ID (ya no se usará)
        // Task<bool> DeleteAsync(int id); // Comentado para dejar claro que no se usa
    }
}
