using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IDetRegistroIssnService
    {
        Task<IEnumerable<DetRegistroIssnListDTO>> GetDetRegistroIssn();
        Task<DetRegistroIssnDTO?> GetDetRegistroIssnById(int idRegistroIssn, int idRevista);
        Task<int> CreateDetRegistroIssn(DetRegistroIssnCreateDTO dto);
        Task<bool> UpdateDetRegistroIssn(DetRegistroIssnUpdateDTO dto);
        Task DeleteDetRegistroIssn(int idRegistroIssn, int idRevista);
        // Nuevo método para crear registro y detalle juntos
        Task<(int IdRegistroIssn, int IdRevista)> CreateRegistroYDetalleAsync(RegistroIssnCreateDTO registroDto, DetRegistroIssnCreateDTO detalleDto);
    }
}
