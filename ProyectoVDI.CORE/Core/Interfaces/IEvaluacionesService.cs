using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IEvaluacionesService
    {
        Task<int> CreateEvaluaciones(EvaluacionesCreateDTO dto);
        Task DeleteEvaluaciones(int id);
        Task<EvaluacionesDTO?> GetEvaluacionesById(int id);
        Task<IEnumerable<EvaluacionesListDTO>> GetEvaluaciones();
        Task<bool> UpdateEvaluaciones(EvaluacionesUpdateDTO dto);
    }
}
