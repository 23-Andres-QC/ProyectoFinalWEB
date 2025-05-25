using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEditorialService
    {
        Task<int> CreateEditorial(EditorialCreateDTO dto);
        Task DeleteEditorial(int id);
        Task<EditorialDTO?> GetEditorialById(int id);
        Task<IEnumerable<EditorialListDTO>> GetEditoriales();
        Task<bool> UpdateEditorial(EditorialUpdateDTO dto);
    }
}
