using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaService
    {
        Task<IEnumerable<RevistaListaCerradaListDTO>> GetAllAsync();
        Task<RevistaListaCerradaDetailDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(RevistaListaCerradaCreateDTO dto);
        Task<bool> UpdateAsync(RevistaListaCerradaUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
