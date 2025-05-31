using ProyectoVDI.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaRepository
    {
        Task<List<Revista>> GetAllAsync();
        Task<List<Revista>> GetAllAlgunasAsync(); // Agregado para simple list
        Task<Revista?> GetByIdAsync(int id);
        Task<Revista?> GetByIssnAsync(string issn); // Nuevo método para buscar por ISSN
        Task<int> CreateAsync(Revista revista);
        Task<int> UpdateAsync(Revista revista);
        Task<string> DeleteAsync(int id);

        // Nuevo método para crear revista con 3 entidades relacionadas
        Task<bool> CrearRevistaConRegistroAsync(Revista revista, int idUsuario, string tipoRevista);

    }
}