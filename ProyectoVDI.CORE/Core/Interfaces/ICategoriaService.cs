using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaListDTO>> GetCategorias();
        Task<CategoriaDTO?> GetCategoriaById(int id);
        Task<int> CreateCategoria(CategoriaCreateDTO dto);
        Task<bool> UpdateCategoria(CategoriaUpdateDTO dto);
        Task DeleteCategoria(int id);
    }
}
