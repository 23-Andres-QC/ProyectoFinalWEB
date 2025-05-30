using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    /*
     * Servicio de lógica de negocio para Profesores.
     * Orquesta operaciones entre la capa de aplicación y el repositorio.
     */
    public class ProfesoresService : IProfesoresService
    {
        private readonly IProfesoresRepository _profesoresRepository;

        public ProfesoresService(IProfesoresRepository profesoresRepository)
        {
            _profesoresRepository = profesoresRepository;
        }

        public async Task<IEnumerable<ProfesoresListDTO>> GetProfesores()
        {
            var profesores = await _profesoresRepository.GetAllAsync();
            var list = new List<ProfesoresListDTO>();
            foreach (var profesor in profesores)
            {
                list.Add(new ProfesoresListDTO
                {
                    IdProfesor = profesor.IdProfesor,
                    NombreyApellido = profesor.NombreyApellido
                });
            }
            return list;
        }

        public async Task<ProfesoresDTO?> GetProfesoresById(int id)
        {
            var profesor = await _profesoresRepository.GetByIdAsync(id);
            if (profesor == null) return null;
            return new ProfesoresDTO
            {
                IdProfesor = profesor.IdProfesor,
                IdCategoria = profesor.IdCategoria,
                Dni = profesor.Dni,
                NombreyApellido = profesor.NombreyApellido,
                Correo = profesor.Correo,
                Estado = profesor.Estado
            };
        }

        public async Task<int> CreateProfesores(ProfesoresCreateDTO dto)
        {
            var profesor = new Profesores
            {
                IdCategoria = dto.IdCategoria,
                Dni = dto.Dni,
                NombreyApellido = dto.NombreyApellido,
                Correo = dto.Correo,
                Estado = dto.Estado ?? 1
            };
            return await _profesoresRepository.CreateAsync(profesor);
        }

        public async Task<bool> UpdateProfesores(ProfesoresUpdateDTO dto)
        {
            var profesor = await _profesoresRepository.GetByIdAsync(dto.IdProfesor);
            if (profesor == null) return false;
            profesor.IdCategoria = dto.IdCategoria;
            profesor.Dni = dto.Dni;
            profesor.NombreyApellido = dto.NombreyApellido;
            profesor.Correo = dto.Correo;
            profesor.Estado = dto.Estado;
            await _profesoresRepository.UpdateAsync(profesor);
            return true;
        }

        public async Task DeleteProfesores(int id)
        {
            await _profesoresRepository.DeleteAsync(id);
        }
    }
}
