using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IMetadatosRevistaIssnRepository
    {
        Task<IEnumerable<MetadatosRevistaIssn>> GetAllAsync();
        Task<MetadatosRevistaIssn?> GetByIdAsync(int id);
        Task<int> CreateAsync(MetadatosRevistaIssn entity);
        Task<bool> UpdateAsync(MetadatosRevistaIssn entity);
        Task<bool> DeleteAsync(int id);
    }
}
