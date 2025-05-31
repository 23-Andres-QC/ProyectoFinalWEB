using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class ProfesoresAdmisService : IProfesoresAdmisService
    {
        private readonly IProfesoresAdmisRepository _repository;
        public ProfesoresAdmisService(IProfesoresAdmisRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProfesoresAdmisListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = new List<ProfesoresAdmisListDTO>();
            foreach (var item in list)
            {
                result.Add(new ProfesoresAdmisListDTO
                {
                    IdProfesorAdmis = item.IdProfesorAdmis,
                    IdCategoria = item.IdCategoria,
                    Dni = item.Dni,
                    NombreyApellido = item.NombreyApellido,
                    Correo = item.Correo,
                    Estado = item.Estado
                });
            }
            return result;
        }

        public async Task<ProfesoresAdmisDetailDTO?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;
            return new ProfesoresAdmisDetailDTO
            {
                IdProfesorAdmis = item.IdProfesorAdmis,
                IdCategoria = item.IdCategoria,
                Dni = item.Dni,
                NombreyApellido = item.NombreyApellido,
                Correo = item.Correo,
                Estado = item.Estado
            };
        }

        public async Task<int> CreateAsync(ProfesoresAdmisCreateDTO dto)
        {
            var entity = new ProfesoresAdmis
            {
                IdCategoria = dto.IdCategoria,
                Dni = dto.Dni,
                NombreyApellido = dto.NombreyApellido,
                Correo = dto.Correo,
                Estado = 1
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(ProfesoresAdmisUpdateDTO dto)
        {
            var entity = new ProfesoresAdmis
            {
                IdProfesorAdmis = dto.IdProfesorAdmis,
                IdCategoria = dto.IdCategoria,
                Dni = dto.Dni,
                NombreyApellido = dto.NombreyApellido,
                Correo = dto.Correo,
                Estado = dto.Estado
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
