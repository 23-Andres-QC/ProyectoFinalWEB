using ProyectoVDI.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Interfaces
{
    public interface IRevistaService
    {
        Task<IEnumerable<RevistaListDTO>> GetRevista(); // simple list
        Task<RevistaDTO?> GetRevistaById(int id); // simple by id
        Task<IEnumerable<RevistaFullDTO>> GetRevistas(); // full list
        Task<RevistaFullDTO?> GetRevistasById(int id); // full by id
        Task<int> CreateRevista(RevistaCreateDTO dto);
        Task<bool> UpdateRevista(RevistaUpdateDTO dto);
        Task DeleteRevista(int id);
        Task<BulkRevistaResultDTO> BulkUpsertRevistasAsync(List<RevistaCreateDTO> revistas); // bulk upsert
        Task<object> RegistrarRevistasConDetalleAsync(RevistaRegistroRequestDTO request); // NUEVO: flujo usuario, tipoRevista, revistas

        // Nuevo método para crear revista con 3 entidades relacionadas
        Task<bool> CrearRevistaConRegistroAsync(RevistaCreacionDTO dto);
        

    }
}