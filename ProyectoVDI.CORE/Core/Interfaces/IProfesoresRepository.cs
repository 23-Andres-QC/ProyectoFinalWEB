using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    internal interface IProfesoresRepository
    {
        Task AddProfesorAsync(Profesores profesor);
        Task DeleteProfesorAsync(int id);
        Task<IEnumerable<Profesores>> GetAllProfesoresAsync();
        Task<Profesores?> GetProfesorById(int id);
        Task UpdateProfesorAsync(Profesores profesor);
    }
}