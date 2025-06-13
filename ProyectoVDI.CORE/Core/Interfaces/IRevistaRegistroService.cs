using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRegistroService
    {
        // GETs
        Task<IEnumerable<RevistaRegistroDTO>> GetAllRevistasAsync();
        Task<RevistaRegistroDTO?> GetRevistaByIssnAsync(string issn);
        Task<IEnumerable<RevistaBasicaDTO>> GetCamposBasicosAsync();
        Task<RevistaBasicaDTO?> GetCamposBasicosByIssnAsync(string issn);
        // POST
        Task<bool> RegistrarRevistasAsync(int idUsuario, string tipoRevista, List<RevistaRegistroDTO> revistas);
        // PUT
        Task<bool> ActualizarRevistaPorIssnAsync(RevistaRegistroDTO dto);
        // DELETE
        Task<bool> EliminarRevistaPorIssnAsync(string issn);
        // NUEVO: Obtener nombres de columnas válidas para consulta distinct en MetadatosRevistaISSN
        Task<IEnumerable<string>> GetMetadatosColumnNamesAsync();
        // NUEVO: Obtener valores distintos de una columna en MetadatosRevistaISSN
        Task<IEnumerable<string>> GetMetadatosDistinctValuesAsync(string columnName);
    }
}
