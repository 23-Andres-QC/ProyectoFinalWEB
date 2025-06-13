using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    // Interfaz para el servicio de Categorias
    public interface ICategoriasService
    {
        // Obtiene todas las categorias
        Task<IEnumerable<CategoriasListDTO>> GetAllAsync();
        // Obtiene una categoria por su ID
        Task<CategoriasDetailDTO?> GetByIdAsync(int id);
        // Crea una nueva categoria
        Task<int> CreateAsync(CategoriasCreateDTO dto);
        // Actualiza una categoria existente
        Task<bool> UpdateAsync(CategoriasUpdateDTO dto);
        // Obtiene descripciones distintas de categorias
        Task<IEnumerable<string>> GetDistinctDescripcionAsync();
        // Elimina (desactiva) una categoria (ya no se usará)
        // Task<bool> DeleteAsync(int id); // Comentado para dejar claro que no se usa
    }
}
