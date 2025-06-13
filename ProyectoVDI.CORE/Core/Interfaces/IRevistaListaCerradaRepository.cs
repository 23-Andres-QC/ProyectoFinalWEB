using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaListaCerradaRepository
    {
        Task<RevistaListaCerrada?> CreateListaCerrada(RevistaListaCerrada entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RevistaListaCerrada>> GetAllAsync();
        Task<RevistaListaCerrada?> GetByNombreAsync(string nombre);
        Task<bool> UpdateAsync(RevistaListaCerrada entity);
        Task<IEnumerable<string>> GetColumnNamesAsync();
        Task<IEnumerable<string>> GetDistinctValuesAsync(string columnName);
    }
}