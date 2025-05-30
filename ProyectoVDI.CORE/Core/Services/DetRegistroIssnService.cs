using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ProyectoVDI.CORE.Core.Services
{
    public class DetRegistroIssnService : IDetRegistroIssnService
    {
        private readonly IDetRegistroISSNRepository _repository;
        private readonly IRegistroIssnService _registroIssnService;

        public DetRegistroIssnService(IDetRegistroISSNRepository repository, IRegistroIssnService registroIssnService)
        {
            _repository = repository;
            _registroIssnService = registroIssnService;
        }

        public async Task<IEnumerable<DetRegistroIssnListDTO>> GetDetRegistroIssn()
        {
            var detalles = await _repository.GetAllAsync();
            var list = new List<DetRegistroIssnListDTO>();
            foreach (var det in detalles)
            {
                list.Add(new DetRegistroIssnListDTO
                {
                    IdRegistroIssn = det.IdRegistroIssn,
                    IdRevista = det.IdRevista
                });
            }
            return list;
        }

        public async Task<DetRegistroIssnDTO?> GetDetRegistroIssnById(int idRegistroIssn, int idRevista)
        {
            var detalles = await _repository.GetAllAsync();
            var det = detalles.Find(x => x.IdRegistroIssn == idRegistroIssn && x.IdRevista == idRevista);
            if (det == null) return null;
            return new DetRegistroIssnDTO
            {
                IdRegistroIssn = det.IdRegistroIssn,
                IdRevista = det.IdRevista,
                TipoRevista = det.TipoRevista
            };
        }

        public async Task<int> CreateDetRegistroIssn(DetRegistroIssnCreateDTO dto)
        {
            var det = new DetRegistroIssn
            {
                IdRegistroIssn = dto.IdRegistroIssn,
                IdRevista = dto.IdRevista,
                TipoRevista = dto.TipoRevista
            };
            await _repository.CreateAsync(det);
            return det.IdRegistroIssn ?? 0;
        }

        // Nuevo método: crea el registro principal y el detalle, asegurando el flujo correcto
        public async Task<(int IdRegistroIssn, int IdRevista)> CreateRegistroYDetalleAsync(RegistroIssnCreateDTO registroDto, DetRegistroIssnCreateDTO detalleDto)
        {
            // 1. Crear registro principal y obtener el ID generado
            int idRegistroIssn = await _registroIssnService.CreateRegistroIssn(registroDto);
            if (idRegistroIssn == 0)
                throw new Exception("No se pudo crear el registro principal ISSN.");

            // 2. Crear el detalle usando el ID generado
            var det = new DetRegistroIssn
            {
                IdRegistroIssn = idRegistroIssn,
                IdRevista = detalleDto.IdRevista,
                TipoRevista = detalleDto.TipoRevista
            };
            var result = await _repository.CreateAsync(det);
            return (result.IdRegistroIssn ?? 0, result.IdRevista ?? 0);
        }

        public async Task<bool> UpdateDetRegistroIssn(DetRegistroIssnUpdateDTO dto)
        {
            var detalles = await _repository.GetAllAsync();
            var det = detalles.Find(x => x.IdRegistroIssn == dto.IdRegistroIssn && x.IdRevista == dto.IdRevista);
            if (det == null) return false;
            det.TipoRevista = dto.TipoRevista;
            await _repository.UpdateAsync(det);
            return true;
        }

        public async Task DeleteDetRegistroIssn(int idRegistroIssn, int idRevista)
        {
            await _repository.DeleteAsync(idRegistroIssn, idRevista);
        }
    }
}
