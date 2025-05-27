using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class EvaluacionesService : IEvaluacionesService
    {
        private readonly IEvaluacionesRepository _evaluacionesRepository;

        public EvaluacionesService(IEvaluacionesRepository evaluacionesRepository)
        {
            _evaluacionesRepository = evaluacionesRepository;
        }

        public async Task<IEnumerable<EvaluacionesListDTO>> GetEvaluaciones()
        {
            var evaluaciones = await _evaluacionesRepository.GetAllAsync();
            var list = new List<EvaluacionesListDTO>();
            foreach (var evaluacion in evaluaciones)
            {
                list.Add(new EvaluacionesListDTO
                {
                    IdEvaluacion = evaluacion.IdEvaluacion,
                    IdRevista = evaluacion.IdRevista
                });
            }
            return list;
        }

        public async Task<EvaluacionesDTO?> GetEvaluacionesById(int id)
        {
            var evaluacion = await _evaluacionesRepository.GetByIdAsync(id);
            if (evaluacion == null) return null;
            return new EvaluacionesDTO
            {
                IdEvaluacion = evaluacion.IdEvaluacion,
                IdRevista = evaluacion.IdRevista,
                Ajg4 = evaluacion.Ajg4,
                Ajg = evaluacion.Ajg,
                AjgS = evaluacion.AjgS,
                Cnrs = evaluacion.Cnrs,
                CnrsS = evaluacion.CnrsS,
                Abdc = evaluacion.Abdc,
                AbdcS = evaluacion.AbdcS,
                AjgExiste = evaluacion.AjgExiste,
                CnrsExiste = evaluacion.CnrsExiste,
                AbdcExiste = evaluacion.AbdcExiste
            };
        }

        public async Task<int> CreateEvaluaciones(EvaluacionesCreateDTO dto)
        {
            var evaluacion = new Evaluaciones
            {
                IdRevista = dto.IdRevista,
                Ajg4 = dto.Ajg4,
                Ajg = dto.Ajg,
                AjgS = dto.AjgS,
                Cnrs = dto.Cnrs,
                CnrsS = dto.CnrsS,
                Abdc = dto.Abdc,
                AbdcS = dto.AbdcS,
                AjgExiste = dto.AjgExiste,
                CnrsExiste = dto.CnrsExiste,
                AbdcExiste = dto.AbdcExiste
            };
            await _evaluacionesRepository.CreateAsync(evaluacion);
            return evaluacion.IdEvaluacion;
        }

        public async Task<bool> UpdateEvaluaciones(EvaluacionesUpdateDTO dto)
        {
            var evaluacion = await _evaluacionesRepository.GetByIdAsync(dto.IdEvaluacion);
            if (evaluacion == null) return false;
            evaluacion.IdRevista = dto.IdRevista;
            evaluacion.Ajg4 = dto.Ajg4;
            evaluacion.Ajg = dto.Ajg;
            evaluacion.AjgS = dto.AjgS;
            evaluacion.Cnrs = dto.Cnrs;
            evaluacion.CnrsS = dto.CnrsS;
            evaluacion.Abdc = dto.Abdc;
            evaluacion.AbdcS = dto.AbdcS;
            evaluacion.AjgExiste = dto.AjgExiste;
            evaluacion.CnrsExiste = dto.CnrsExiste;
            evaluacion.AbdcExiste = dto.AbdcExiste;
            await _evaluacionesRepository.UpdateAsync(evaluacion);
            return true;
        }

        public async Task DeleteEvaluaciones(int id)
        {
            await _evaluacionesRepository.DeleteAsync(id);
        }
    }
}
