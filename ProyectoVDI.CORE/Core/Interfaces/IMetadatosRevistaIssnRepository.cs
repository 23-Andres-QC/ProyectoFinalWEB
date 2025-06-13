using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IMetadatosRevistaIssnRepository
    {
        Task<int> CreateAsync(MetadatosRevistaIssn entity);
        Task<IEnumerable<MetadatosRevistaIssn>> GetAllAsync();
        Task<MetadatosRevistaIssn?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(MetadatosRevistaIssn entity);
        // NUEVO: Obtener nombres de columnas válidas para consulta distinct
        Task<IEnumerable<string>> GetColumnNamesAsync();
        // NUEVO: Obtener valores distintos de una columna
        Task<IEnumerable<string>> GetDistinctValuesAsync(string columnName);
    }
}