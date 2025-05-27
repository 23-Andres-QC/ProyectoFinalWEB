using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEvaluacionesService
    {
        Task<IEnumerable<EvaluacionesListDTO>> GetEvaluaciones();
        Task<EvaluacionesDTO?> GetEvaluacionesById(int id);
        Task<int> CreateEvaluaciones(EvaluacionesCreateDTO dto);
        Task<bool> UpdateEvaluaciones(EvaluacionesUpdateDTO dto);
        Task DeleteEvaluaciones(int id);
    }
}
