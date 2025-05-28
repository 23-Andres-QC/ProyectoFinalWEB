using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    // Servicio para la lógica de negocio relacionada con evaluaciones
    public class EvaluacionesService : IEvaluacionesService
    {
        // Repositorio de evaluaciones inyectado
        private readonly IEvaluacionesRepository _evaluacionesRepository;

        // Constructor que recibe el repositorio
        public EvaluacionesService(IEvaluacionesRepository evaluacionesRepository)
        {
            _evaluacionesRepository = evaluacionesRepository;
        }

        // Obtiene la lista de evaluaciones y la transforma a DTO para la vista/listado
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

        // Obtiene una evaluación por su ID y la transforma a DTO detallado
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

        // Crea una nueva evaluación a partir de un DTO de creación
        public async Task<int> CreateEvaluaciones(EvaluacionesCreateDTO dto)
       
