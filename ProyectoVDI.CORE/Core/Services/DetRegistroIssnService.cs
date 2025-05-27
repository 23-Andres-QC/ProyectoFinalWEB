using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class DetRegistroIssnService : IDetRegistroIssnService
    {
        private readonly IDetRegistroISSNRepository _repository;

        public DetRegistroIssnService(IDetRegistroISSNRepository repository)
        {
            _repository = repository;
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
                IdTipo = det.IdTipo
            };
        }

        public async Task<int> CreateDetRegistroIssn(DetRegistroIssnCreateDTO dto)
        {
            var det = new DetRegistroIssn
            {
                IdRegistroIssn = dto.IdRegistroIssn,
                IdRevista = dto.IdRevista,
                IdTipo = dto.IdTipo
            };
            await _repository.CreateAsync(det);
            return det.IdRegistroIssn ?? 0;
        }

        public async Task<bool> UpdateDetRegistroIssn(DetRegistroIssnUpdateDTO dto)
        {
            var detalles = await _repository.GetAllAsync();
            var det = detalles.Find(x => x.IdRegistroIssn == dto.IdRegistroIssn && x.IdRevista == dto.IdRevista);
            if (det == null) return false;
            det.IdTipo = dto.IdTipo;
            await _repository.UpdateAsync(det);
            return true;
        }

        public async Task DeleteDetRegistroIssn(int idRegistroIssn, int idRevista)
        {
            await _repository.DeleteAsync(idRegistroIssn, idRevista);
        }
    }
}
