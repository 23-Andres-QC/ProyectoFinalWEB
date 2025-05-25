using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroIssnService
    {
        Task<int> CreateRegistroIssn(RegistroIssnCreateDTO dto);
        Task DeleteRegistroIssn(int id);
        Task<RegistroIssnDTO?> GetRegistroIssnById(int id);
        Task<IEnumerable<RegistroIssnListDTO>> GetRegistroIssns();
        Task<bool> UpdateRegistroIssn(RegistroIssnUpdateDTO dto);
    }
}
