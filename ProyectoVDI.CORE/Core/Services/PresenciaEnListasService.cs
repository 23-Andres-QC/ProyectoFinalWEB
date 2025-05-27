using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class PresenciaEnListasService 
    {
        private readonly IPresenciaEnListasRepository _presenciaEnListasRepository;

        public PresenciaEnListasService(IPresenciaEnListasRepository presenciaEnListasRepository)
        {
            _presenciaEnListasRepository = presenciaEnListasRepository;
        }

        public async Task<IEnumerable<PresenciaEnListasListDTO>> GetPresenciaEnListas()
        {
            var listas = await _presenciaEnListasRepository.GetAllAsync();
            var list = new List<PresenciaEnListasListDTO>();
            foreach (var item in listas)
            {
                list.Add(new PresenciaEnListasListDTO
                {
                    IdLista = item.IdLista,
                    IdRevista = item.IdRevista
                });
            }
            return list;
        }

        public async Task<PresenciaEnListasDTO?> GetPresenciaEnListasById(int id)
        {
            var item = await _presenciaEnListasRepository.GetByIdAsync(id);
            if (item == null) return null;
            return new PresenciaEnListasDTO
            {
                IdLista = item.IdLista,
                IdRevista = item.IdRevista,
                AlMenosEnUnaLista = item.AlMenosEnUnaLista,
                SoloEnUnaLista = item.SoloEnUnaLista,
                _216bEspecial = item._216bEspecial,
                Top50 = item.Top50,
                Multiple = item.Múltiple,
                MultyYAlMenosUnaLista = item.MultyYAlMenosUnaLista
            };
        }

        public async Task<int> CreatePresenciaEnListas(PresenciaEnListasCreateDTO dto)
        {
            var item = new PresenciaEnListas
            {
                IdRevista = dto.IdRevista,
                AlMenosEnUnaLista = dto.AlMenosEnUnaLista,
                SoloEnUnaLista = dto.SoloEnUnaLista,
                _216bEspecial = dto._216bEspecial,
                Top50 = dto.Top50,
                Múltiple = dto.Multiple,
                MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista
            };
            return await _presenciaEnListasRepository.CreateAsync(item);
        }

        public async Task<bool> UpdatePresenciaEnListas(PresenciaEnListasUpdateDTO dto)
        {
            var item = await _presenciaEnListasRepository.GetByIdAsync(dto.IdLista);
            if (item == null) return false;
            item.IdRevista = dto.IdRevista;
            item.AlMenosEnUnaLista = dto.AlMenosEnUnaLista;
            item.SoloEnUnaLista = dto.SoloEnUnaLista;
            item._216bEspecial = dto._216bEspecial;
            item.Top50 = dto.Top50;
            item.Múltiple = dto.Multiple;
            item.MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista;
            await _presenciaEnListasRepository.UpdateAsync(item);
            return true;
        }

        public async Task DeletePresenciaEnListas(int id)
        {
            await _presenciaEnListasRepository.DeleteAsync(id);
        }
    }
}
