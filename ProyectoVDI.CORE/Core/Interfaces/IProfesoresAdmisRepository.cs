using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IProfesoresAdmisRepository
    {
        Task<IEnumerable<ProfesoresAdmis>> GetAllAsync();
        Task<ProfesoresAdmis?> GetByIdAsync(int id);
        Task<int> CreateAsync(ProfesoresAdmis entity);
        Task<bool> UpdateAsync(ProfesoresAdmis entity);
        Task<bool> DeleteAsync(int id);
    }
}
