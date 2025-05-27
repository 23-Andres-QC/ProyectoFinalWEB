using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IPresenciaEnListasService
    {
        Task<IEnumerable<PresenciaEnListasListDTO>> GetPresenciaEnListas();
        Task<PresenciaEnListasDTO?> GetPresenciaEnListasById(int id);
        Task<int> CreatePresenciaEnListas(PresenciaEnListasCreateDTO dto);
        Task<bool> UpdatePresenciaEnListas(PresenciaEnListasUpdateDTO dto);
        Task DeletePresenciaEnListas(int id);
    }
}
