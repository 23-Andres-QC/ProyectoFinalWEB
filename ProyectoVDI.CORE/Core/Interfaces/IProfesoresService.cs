using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresService
    {
        Task<IEnumerable<ProfesoresListDTO>> GetProfesores();
        Task<ProfesoresDTO?> GetProfesoresById(int id);
        Task<int> CreateProfesores(ProfesoresCreateDTO dto);
        Task<bool> UpdateProfesores(ProfesoresUpdateDTO dto);
        Task DeleteProfesores(int id);
    }
}
