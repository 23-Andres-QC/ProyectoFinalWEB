using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IAutoriaService
    {
        Task<int> CreateAutoria(AutoriaCreateDTO dto);
        Task DeleteAutoria(int id);
        Task<AutoriaDTO?> GetAutoriaById(int id);
        Task<IEnumerable<AutoriaListDTO>> GetAutorias();
        Task<bool> UpdateAutoria(AutoriaUpdateDTO dto);
    }
}
