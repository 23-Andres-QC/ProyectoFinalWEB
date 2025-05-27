using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RegistroIssnService
    {
        private readonly IRegistroISSNRepository _repository;

        public RegistroIssnService(IRegistroISSNRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RegistroIssnListDTO>> GetRegistroIssns()
        {
            var registros = await _repository.GetAllAsync();
            var list = new List<RegistroIssnListDTO>();
            foreach (var reg in registros)
            {
                list.Add(new RegistroIssnListDTO
                {
                    IdRegistroIssn = reg.IdRegistroIssn,
                    IdUsuario = reg.IdUsuario
                });
            }
            return list;
        }

        public async Task<RegistroIssnDTO?> GetRegistroIssnById(int id)
        {
            var reg = await _repository.GetByIdAsync(id);
            if (reg == null) return null;
            return new RegistroIssnDTO
            {
                IdRegistroIssn = reg.IdRegistroIssn,
                IdUsuario = reg.IdUsuario,
                FechaRegistro = reg.FechaRegistro
            };
        }

        public async Task<int> CreateRegistroIssn(RegistroIssnCreateDTO dto)
        {
            var reg = new RegistroIssn
            {
                IdUsuario = dto.IdUsuario,
                FechaRegistro = dto.FechaRegistro
            };
            await _repository.CreateAsync(reg);
            return reg.IdRegistroIssn;
        }

        public async Task<bool> UpdateRegistroIssn(RegistroIssnUpdateDTO dto)
        {
            var reg = await _repository.GetByIdAsync(dto.IdRegistroIssn);
            if (reg == null) return false;
            reg.IdUsuario = dto.IdUsuario;
            reg.FechaRegistro = dto.FechaRegistro;
            await _repository.UpdateAsync(reg);
            return true;
        }

        public async Task DeleteRegistroIssn(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
