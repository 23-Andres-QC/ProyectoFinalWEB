using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEditorialService
    {
        Task<IEnumerable<EditorialListDTO>> GetEditoriales();
        Task<EditorialDTO?> GetEditorialById(int id);
        Task<int> CreateEditorial(EditorialCreateDTO dto);
        Task<bool> UpdateEditorial(EditorialUpdateDTO dto);
        Task DeleteEditorial(int id);
    }
}
