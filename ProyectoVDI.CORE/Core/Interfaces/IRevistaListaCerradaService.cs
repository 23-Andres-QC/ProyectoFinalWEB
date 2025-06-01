using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaService
    {
        Task<IEnumerable<RevistaListaCerradaListDTO>> GetAllAsync();
        Task<bool> ImportarDesdeExcelAsync(byte[] archivoExcelBytes);
    }
}
