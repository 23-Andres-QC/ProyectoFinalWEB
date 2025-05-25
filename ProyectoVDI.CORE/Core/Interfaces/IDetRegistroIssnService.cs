using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroIssnService
    {
        Task<int> CreateDetRegistroIssn(DetRegistroIssnCreateDTO dto);
        Task DeleteDetRegistroIssn(int idRegistroIssn, int idRevista);
        Task<DetRegistroIssnDTO?> GetDetRegistroIssnById(int idRegistroIssn, int idRevista);
        Task<IEnumerable<DetRegistroIssnListDTO>> GetDetRegistroIssn();
        Task<bool> UpdateDetRegistroIssn(DetRegistroIssnUpdateDTO dto);
    }
}
