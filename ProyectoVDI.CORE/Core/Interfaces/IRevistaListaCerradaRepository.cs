using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaRepository
    {
        Task<IEnumerable<RevistaListaCerrada>> GetAllAsync();
        Task<int> CreateAsync(RevistaListaCerrada entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(RevistaListaCerrada entity);
        Task<RevistaListaCerrada?> GetByNombreAsync(string nombre);
    }
}
