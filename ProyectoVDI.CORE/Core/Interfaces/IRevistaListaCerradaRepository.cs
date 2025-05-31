using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaRepository
    {
        Task<IEnumerable<RevistaListaCerrada>> GetAllAsync();
        Task<RevistaListaCerrada?> GetByIdAsync(int id);
        Task<int> CreateAsync(RevistaListaCerrada entity);
        Task<bool> UpdateAsync(RevistaListaCerrada entity);
        Task<bool> DeleteAsync(int id);
    }
}
