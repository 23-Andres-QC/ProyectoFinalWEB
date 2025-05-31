using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRegistroIssnService
    {
        Task<IEnumerable<RegistroIssnListDTO>> GetRegistroIssns();
        Task<RegistroIssnDTO?> GetRegistroIssnById(int id);
        Task<int> CreateRegistroIssn(RegistroIssnCreateDTO dto);
        Task<bool> UpdateRegistroIssn(RegistroIssnUpdateDTO dto);
        Task DeleteRegistroIssn(int id);
                

    }
}
