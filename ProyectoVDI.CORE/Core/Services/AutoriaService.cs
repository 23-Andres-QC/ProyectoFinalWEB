using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class AutoriaService 
    {
        private readonly IAutoriaRepository _autoriaRepository;

        public AutoriaService(IAutoriaRepository autoriaRepository)
        {
            _autoriaRepository = autoriaRepository;
        }

        public async Task<IEnumerable<AutoriaListDTO>> GetAutorias()
        {
            var autorias = await _autoriaRepository.GetAllAsync();
            var list = new List<AutoriaListDTO>();
            foreach (var autoria in autorias)
            {
                list.Add(new AutoriaListDTO
                {
                    IdAutoria = autoria.IdAutoria,
                    IdRevista = autoria.IdRevista
                });
            }
            return list;
        }

        public async Task<AutoriaDTO?> GetAutoriaById(int id)
        {
            var autoria = await _autoriaRepository.GetByIdAsync(id);
            if (autoria == null) return null;
            return new AutoriaDTO
            {
                IdAutoria = autoria.IdAutoria,
                IdRevista = autoria.IdRevista,
                CoautoriaEsan = autoria.CoautoriaEsan,
                PosicionDelAutor = autoria.PosiciónDelAutor
            };
        }

        public async Task<int> CreateAutoria(AutoriaCreateDTO dto)
        {
            var autoria = new Autoria
            {
                IdRevista = dto.IdRevista,
                CoautoriaEsan = dto.CoautoriaEsan,
                PosiciónDelAutor = dto.PosicionDelAutor
            };
            return await _autoriaRepository.CreateAsync(autoria);
        }

        public async Task<bool> UpdateAutoria(AutoriaUpdateDTO dto)
        {
            var autoria = await _autoriaRepository.GetByIdAsync(dto.IdAutoria);
            if (autoria == null) return false;
            autoria.IdRevista = dto.IdRevista;
            autoria.CoautoriaEsan = dto.CoautoriaEsan;
            autoria.PosiciónDelAutor = dto.PosicionDelAutor;
            await _autoriaRepository.UpdateAsync(autoria);
            return true;
        }

        public async Task DeleteAutoria(int id)
        {
            await _autoriaRepository.DeleteAsync(id);
        }
    }
}
