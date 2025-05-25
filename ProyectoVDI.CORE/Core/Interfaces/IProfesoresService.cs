using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresService
    {
        Task<int> CreateProfesores(ProfesoresCreateDTO dto);
        Task DeleteProfesores(int id);
        Task<ProfesoresDTO?> GetProfesoresById(int id);
        Task<IEnumerable<ProfesoresListDTO>> GetProfesores();
        Task<bool> UpdateProfesores(ProfesoresUpdateDTO dto);
    }
}
