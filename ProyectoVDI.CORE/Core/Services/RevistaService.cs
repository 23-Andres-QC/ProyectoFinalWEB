using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaService 
    {
        private readonly IRevistaRepository _revistaRepository;

        public RevistaService(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }

        public async Task<IEnumerable<RevistaListDTO>> GetRevistas()
        {
            var revistas = await _revistaRepository.GetAllAsync();
            var list = new List<RevistaListDTO>();
            foreach (var revista in revistas)
            {
                list.Add(new RevistaListDTO
                {
                    IdRevista = revista.IdRevista,
                    Nombre = revista.Nombre,
                    Issn = revista.Issn
                });
            }
            return list;
        }

        public async Task<RevistaDTO?> GetRevistaById(int id)
        {
            var revista = await _revistaRepository.GetByIdAsync(id);
            if (revista == null) return null;
            return new RevistaDTO
            {
                IdRevista = revista.IdRevista,
                Issn = revista.Issn,
                Nombre = revista.Nombre,
                Country = revista.Country,
                Jif = revista.Jif,
                N = revista.N
            };
        }

        public async Task<int> CreateRevista(RevistaCreateDTO dto)
        {
            var revista = new Revista
            {
                Issn = dto.Issn,
                Nombre = dto.Nombre,
                Country = dto.Country,
                Jif = dto.Jif,
                N = dto.N
            };
            await _revistaRepository.CreateAsync(revista);
            return revista.IdRevista;
        }

        public async Task<bool> UpdateRevista(RevistaUpdateDTO dto)
        {
            var revista = await _revistaRepository.GetByIdAsync(dto.IdRevista);
            if (revista == null) return false;
            revista.Issn = dto.Issn;
            revista.Nombre = dto.Nombre;
            revista.Country = dto.Country;
            revista.Jif = dto.Jif;
            revista.N = dto.N;
            await _revistaRepository.UpdateAsync(revista);
            return true;
        }

        public async Task DeleteRevista(int id)
        {
            await _revistaRepository.DeleteAsync(id);
        }
    }
}
