using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class EditorialService 
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialService(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        public async Task<IEnumerable<EditorialListDTO>> GetEditoriales()
        {
            var editoriales = await _editorialRepository.GetAllAsync();
            var list = new List<EditorialListDTO>();
            foreach (var editorial in editoriales)
            {
                list.Add(new EditorialListDTO
                {
                    IdEditorial = editorial.IdEditorial,
                    IdRevista = editorial.IdRevista
                });
            }
            return list;
        }

        public async Task<EditorialDTO?> GetEditorialById(int id)
        {
            var editorial = await _editorialRepository.GetByIdAsync(id);
            if (editorial == null) return null;
            return new EditorialDTO
            {
                IdEditorial = editorial.IdEditorial,
                IdRevista = editorial.IdRevista,
                Mdpi = editorial.Mdpi,
                Insights = editorial.Insights,
                BeallSList = editorial.BeallSList
            };
        }

        public async Task<int> CreateEditorial(EditorialCreateDTO dto)
        {
            var editorial = new Editorial
            {
                IdRevista = dto.IdRevista,
                Mdpi = dto.Mdpi,
                Insights = dto.Insights,
                BeallSList = dto.BeallSList
            };
            return await _editorialRepository.CreateAsync(editorial);
        }

        public async Task<bool> UpdateEditorial(EditorialUpdateDTO dto)
        {
            var editorial = await _editorialRepository.GetByIdAsync(dto.IdEditorial);
            if (editorial == null) return false;
            editorial.IdRevista = dto.IdRevista;
            editorial.Mdpi = dto.Mdpi;
            editorial.Insights = dto.Insights;
            editorial.BeallSList = dto.BeallSList;
            await _editorialRepository.UpdateAsync(editorial);
            return true;
        }

        public async Task DeleteEditorial(int id)
        {
            await _editorialRepository.DeleteAsync(id);
        }
    }
}
