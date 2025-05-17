using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    internal interface IRevistaRepository
    {
        Task AddRevistaAsync(Revista revista);
        Task DeleteRevistaAsync(int id);
        Task<IEnumerable<Revista>> GetAllRevistasAsync();
        Task<Revista?> GetRevistaById(int id);
        Task UpdateRevistaAsync(Revista revista);
    }
}