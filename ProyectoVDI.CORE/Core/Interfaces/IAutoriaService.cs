using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IAutoriaService
    {
        Task<IEnumerable<AutoriaListDTO>> GetAutorias();
        Task<AutoriaDTO?> GetAutoriaById(int id);
        Task<int> CreateAutoria(AutoriaCreateDTO dto);
        Task<bool> UpdateAutoria(AutoriaUpdateDTO dto);
        Task DeleteAutoria(int id);
    }
}
