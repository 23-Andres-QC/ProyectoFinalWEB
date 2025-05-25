using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task<int> CreateCategoria(CategoriaCreateDTO dto);
        Task DeleteCategoria(int id);
        Task<CategoriaDTO?> GetCategoriaById(int id);
        Task<IEnumerable<CategoriaListDTO>> GetCategorias();
        Task<bool> UpdateCategoria(CategoriaUpdateDTO dto);
    }
}
