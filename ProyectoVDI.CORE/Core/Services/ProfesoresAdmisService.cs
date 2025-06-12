using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    // Servicio de aplicación para la gestión de profesores.
    // Implementa la lógica de negocio y orquesta las operaciones CRUD usando el repositorio.
    public class ProfesoresAdmisService : IProfesoresAdmisService
    {
        // Inyección del repositorio de profesores
        private readonly IProfesoresAdmisRepository _repository;
        public ProfesoresAdmisService(IProfesoresAdmisRepository repository)
        {
            _repository = repository;
        }

        // Obtiene la lista de todos los profesores registrados en el sistema.
        public async Task<IEnumerable<ProfesoresAdmisListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<ProfesoresAdmisListDTO>();
            foreach (var item in list)
            {
                result.Add(new ProfesoresAdmisListDTO
                {
                    IdProfesorAdmis = item.IdProfesorAdmis,
                    IdCateg = item.IdCategoria, // ahora vuelve mas la categoria id
                    Categoria = item.IdCategoriaNavigation?.Descripcion, // Ahora muestra la descripción
                    Dni = item.Dni,
                    NombreyApellido = item.NombreyApellido,
                    Correo = item.Correo,
                    Estado = item.Estado == 1 ? "Activo" : "Inactivo"
                });
            }
            return result;
        }

        // Obtiene el detalle de un profesor específico por su ID.
        public async Task<ProfesoresAdmisDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new ProfesoresAdmisDetailDTO
            {
                IdProfesorAdmis = item.IdProfesorAdmis,
                IdCategoria = item.IdCategoriaNavigation?.Descripcion, // Ahora muestra la descripción
                Dni = item.Dni,
                NombreyApellido = item.NombreyApellido,
                Correo = item.Correo,
                Estado = item.Estado
            };
        }

        // Registra un nuevo profesor en el sistema.
        // El estado ahora se toma del DTO y no se asigna automáticamente.
        public async Task<int> CreateAsync(ProfesoresAdmisCreateDTO dto)
        {
            var entity = new ProfesoresAdmis
            {
                IdCategoria = dto.IdCategoria,
                Dni = dto.Dni,
                NombreyApellido = dto.NombreyApellido,
                Correo = dto.Correo,
                Estado = dto.Estado // El estado es proporcionado manualmente
            };
            return await _repository.CreateAsync(entity);
        }

        // Actualiza los datos de un profesor existente.
        //api/
        public async Task<bool> UpdateAsync(ProfesoresAdmisUpdateDTO dto)
        {
            var entity = new ProfesoresAdmis
            {
                IdProfesorAdmis = dto.IdProfesorAdmis,
                IdCategoria = dto.IdCategoria,
                Dni = dto.Dni,
                NombreyApellido = dto.NombreyApellido,
                Correo = dto.Correo,
                Estado = dto.Estado == "Activo" ? 1 : 0
            };
            return await _repository.UpdateAsync(entity);
        }

        // Elimina un profesor del sistema por su ID.
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
