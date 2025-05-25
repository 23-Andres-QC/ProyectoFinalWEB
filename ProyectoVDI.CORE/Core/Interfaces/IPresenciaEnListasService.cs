using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPresenciaEnListasService
    {
        Task<int> CreatePresenciaEnListas(PresenciaEnListasCreateDTO dto);
        Task DeletePresenciaEnListas(int id);
        Task<PresenciaEnListasDTO?> GetPresenciaEnListasById(int id);
        Task<IEnumerable<PresenciaEnListasListDTO>> GetPresenciaEnListas();
        Task<bool> UpdatePresenciaEnListas(PresenciaEnListasUpdateDTO dto);
    }
}
