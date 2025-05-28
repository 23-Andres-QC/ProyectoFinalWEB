using Microsoft.VisualBasic;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RegistroIssnService : IRegistroIssnService
    {
        private readonly IRegistroISSNRepository _repository;

        public RegistroIssnService(IRegistroISSNRepository repository)
        {
            _repository = repository;
        }



        //create un Registro ISSN
        // POST api/RegistroIssn/CreateRegistroIssn

        public async Task<bool> CreateRegistroIssnAsync(CreateRegistroIssnDTO dto)
        {
            var entity = new RegistroIssn
            {
                IdUsuario = dto.IdUsuario,
                FechaRegistro = DateOnly.FromDateTime(DateTime.Now)
            };

            return await _repository.CreateAsync(entity);
        }

        // Obtener todos los registros ISSN
        // GET api/RegistroIssn/GetAllRegistroIssns
        public async Task<IEnumerable<ListAllRegistroIssnDTO>> GetAllRegistroIssnsAsync()
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(r => new ListAllRegistroIssnDTO
            {
                IdRegistroIssn = r.IdRegistroIssn,
                IdUsuario = r.IdUsuario,
                FechaRegistro = r.FechaRegistro
            });
        }


        // Obtener un registro ISSN por ID
        // GET api/RegistroIssn/GetRegistroIssnById/{id}
        public async Task<RegistroIssnDTO> GetRegistroIssnByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return new RegistroIssnDTO
            {
                IdRegistroIssn = entity.IdRegistroIssn,
                IdUsuario = entity.IdUsuario,
                FechaRegistro = entity.FechaRegistro
            };
        }


        // Método adicional para obtener por fecha 
        // GET api/RegistroIssn/GetRegistroIssnByFecha/{fecha}
        public async Task<IEnumerable<ListAllRegistroIssnDTO>> GetRegistroIssnByFechaAsync(DateOnly fecha)
        {
            var registros = await _repository.GetByFechaAsync(fecha);

            return registros.Select(r => new ListAllRegistroIssnDTO
            {
                IdRegistroIssn = r.IdRegistroIssn,
                IdUsuario = r.IdUsuario,
                FechaRegistro = r.FechaRegistro
            });
        }


        // Actualizar un registro ISSN
        // PUT api/RegistroIssn/UpdateRegistroIssn
        public async Task<bool> UpdateRegistroIssnAsync(UpdateRegistroIssnDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.IdRegistroIssn);
            if (entity == null)
                return false;

            entity.IdUsuario = dto.IdUsuario;
            entity.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);

            return await _repository.UpdateAsync(entity);
        }

        // Eliminar un registro ISSN
        // DELETE api/RegistroIssn/DeleteRegistroIssn/{id}
        public async Task<bool> DeleteRegistroIssnAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }


    }
}
