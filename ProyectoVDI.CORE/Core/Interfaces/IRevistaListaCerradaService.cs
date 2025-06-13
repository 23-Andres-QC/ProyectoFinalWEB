using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaService
    {
        Task<IEnumerable<ListaCerradaRegistroDTO>> GetAllLCDAsync();
        Task<ListaCerradaRegistroDTO?> GetLCDByIssnAsync(string issn);
        Task<bool> RegistrarLCDAsync(int idUsuario, List<ListaCerradaRegistroDTO> revistas);
        Task<bool> ActualizarLCDPorIssnAsync(ListaCerradaRegistroDTO dto);
        Task<bool> EliminarLCDPorIssnAsync(string issn);
        Task<IEnumerable<string>> GetDistinctCategoriasAsync();
        Task<IEnumerable<string>> GetColumnNamesAsync();
        Task<IEnumerable<string>> GetDistinctValuesAsync(string columnName);
    }
}
