using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaListaCerradaService : IRevistaListaCerradaService
    {
        private readonly IRevistaListaCerradaRepository _lcdRepo;
        private readonly IRevistaRepository _revistaRepo;
        private readonly IIssnsRevistaRepository _issnRepo;
        private readonly IRegistroRevistasRepository _registroRepo;
        private readonly IDetRegistroRevistaRepository _detRepo;

        public RevistaListaCerradaService(
            IRevistaListaCerradaRepository lcdRepo,
            IRevistaRepository revistaRepo,
            IIssnsRevistaRepository issnRepo,
            IRegistroRevistasRepository registroRepo,
            IDetRegistroRevistaRepository detRepo)
        {
            _lcdRepo = lcdRepo;
            _revistaRepo = revistaRepo;
            _issnRepo = issnRepo;
            _registroRepo = registroRepo;
            _detRepo = detRepo;
        }

        public async Task<IEnumerable<ListaCerradaRegistroDTO>> GetAllLCDAsync()
        {
            var lcds = await _lcdRepo.GetAllAsync();
            var issns = await _issnRepo.GetAllAsync();
            var revistas = await _revistaRepo.GetAllAsync();
            return lcds.Select(lcd => {
                var issnList = issns.Where(i => i.IdRevista == lcd.IdRevista).Select(i => i.Issn).ToList();
                return new ListaCerradaRegistroDTO
                {
                    ISSN = issnList.ElementAtOrDefault(0) ?? string.Empty,
                    ISSN2 = issnList.ElementAtOrDefault(1) ?? string.Empty,
                    ISSN3 = issnList.ElementAtOrDefault(2) ?? string.Empty,
                    Nombre = lcd.Nombre ?? string.Empty,
                    Categoria2 = lcd.Categoria ?? string.Empty,
                    Puntaje = lcd.Puntaje,
                    IncentivoUSD = lcd.IncentivoUsd,
                    SCOPUS = lcd.Scopus ?? string.Empty,
                    WoS_Q = lcd.WoSQ ?? string.Empty,
                    ESCI_Q = lcd.EsciQ ?? string.Empty,
                    AJG = lcd.Ajg ?? string.Empty,
                    CNRS = lcd.Cnrs ?? string.Empty,
                    ABDC = lcd.Abdc ?? string.Empty,
                    WoS_LATAM = lcd.WoSLatam ?? string.Empty
                };
            });
        }

        public async Task<ListaCerradaRegistroDTO?> GetLCDByIssnAsync(string issn)
        {
            var issnObj = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == issn);
            if (issnObj == null || !issnObj.IdRevista.HasValue) return null;
            var lcd = (await _lcdRepo.GetAllAsync()).FirstOrDefault(x => x.IdRevista == issnObj.IdRevista);
            if (lcd == null) return null;
            var issnList = (await _issnRepo.GetAllAsync()).Where(i => i.IdRevista == lcd.IdRevista).Select(i => i.Issn).ToList();
            return new ListaCerradaRegistroDTO
            {
                ISSN = issnList.ElementAtOrDefault(0) ?? string.Empty,
                ISSN2 = issnList.ElementAtOrDefault(1) ?? string.Empty,
                ISSN3 = issnList.ElementAtOrDefault(2) ?? string.Empty,
                Nombre = lcd.Nombre ?? string.Empty,
                Categoria2 = lcd.Categoria ?? string.Empty,
                Puntaje = lcd.Puntaje,
                IncentivoUSD = lcd.IncentivoUsd,
                SCOPUS = lcd.Scopus ?? string.Empty,
                WoS_Q = lcd.WoSQ ?? string.Empty,
                ESCI_Q = lcd.EsciQ ?? string.Empty,
                AJG = lcd.Ajg ?? string.Empty,
                CNRS = lcd.Cnrs ?? string.Empty,
                ABDC = lcd.Abdc ?? string.Empty,
                WoS_LATAM = lcd.WoSLatam ?? string.Empty
            };
        }

        public async Task<bool> RegistrarLCDAsync(int idUsuario, List<ListaCerradaRegistroDTO> revistas)
        {
            var registro = new RegistroRevistas
            {
                IdUsuario = idUsuario,
                FechaRegistro = DateTime.UtcNow
            };
            int idRegistro = await _registroRepo.CreateAsync(registro);
            foreach (var dto in revistas)
            {
                var issns = new[] { dto.ISSN, dto.ISSN2, dto.ISSN3 }
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var issnEntities = (await _issnRepo.GetAllAsync())
                    .Where(x => issns.Contains(x.Issn)).ToList();
                int? idRevista = issnEntities.FirstOrDefault()?.IdRevista;
                Revista revista;
                if (idRevista.HasValue)
                {
                    revista = await _revistaRepo.GetByIdAsync(idRevista.Value);
                    if (revista == null) continue;
                    revista.Nombre = dto.Nombre;
                    revista.TipoLista = "LCD";
                    revista.Estado = 1;
                    await _revistaRepo.UpdateAsync(revista);
                    // Agregar ISSN faltantes
                    var existentes = issnEntities.Select(x => x.Issn).ToList();
                    foreach (var issn in issns)
                    {
                        if (!existentes.Contains(issn))
                        {
                            await _issnRepo.CreateAsync(new IssnsRevista { Issn = issn, IdRevista = revista.IdRevista });
                        }
                    }
                }
                else
                {
                    revista = new Revista
                    {
                        Nombre = dto.Nombre,
                        TipoLista = "LCD",
                        Estado = 1
                    };
                    idRevista = await _revistaRepo.CreateAsync(revista);
                    foreach (var issn in issns)
                    {
                        await _issnRepo.CreateAsync(new IssnsRevista { Issn = issn, IdRevista = idRevista.Value });
                    }
                }
                // Crear o actualizar RevistaListaCerrada
                var lcd = new RevistaListaCerrada
                {
                    IdRevista = idRevista.Value,
                    Nombre = dto.Nombre,
                    Categoria = dto.Categoria2,
                    Puntaje = dto.Puntaje,
                    IncentivoUsd = dto.IncentivoUSD,
                    Scopus = dto.SCOPUS,
                    WoSQ = dto.WoS_Q,
                    EsciQ = dto.ESCI_Q,
                    Ajg = dto.AJG,
                    Cnrs = dto.CNRS,
                    Abdc = dto.ABDC,
                    WoSLatam = dto.WoS_LATAM
                };
                var actualizado = await _lcdRepo.UpdateAsync(lcd);
                if (!actualizado)
                {
                    await _lcdRepo.CreateListaCerrada(lcd);
                }
                // Registrar detalle
                var det = new DetRegistroRevista
                {
                    IdRegistro = idRegistro,
                    IdRevista = idRevista.Value
                };
                await _detRepo.CreateAsync(det);
            }
            return true;
        }

        public async Task<bool> ActualizarLCDPorIssnAsync(ListaCerradaRegistroDTO dto)
        {
            var issns = new[] { dto.ISSN, dto.ISSN2, dto.ISSN3 }
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            var issnEntities = (await _issnRepo.GetAllAsync())
                .Where(x => issns.Contains(x.Issn)).ToList();
            int? idRevista = issnEntities.FirstOrDefault()?.IdRevista;
            if (!idRevista.HasValue) return false;
            var revista = await _revistaRepo.GetByIdAsync(idRevista.Value);
            if (revista == null) return false;
            revista.Nombre = dto.Nombre;
            revista.TipoLista = "LCD";
            revista.Estado = 1;
            await _revistaRepo.UpdateAsync(revista);
            // Agregar ISSN faltantes
            var existentes = issnEntities.Select(x => x.Issn).ToList();
            foreach (var issn in issns)
            {
                if (!existentes.Contains(issn))
                {
                    await _issnRepo.CreateAsync(new IssnsRevista { Issn = issn, IdRevista = revista.IdRevista });
                }
            }
            // Actualizar RevistaListaCerrada
            var lcd = new RevistaListaCerrada
            {
                IdRevista = idRevista.Value,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria2,
                Puntaje = dto.Puntaje,
                IncentivoUsd = dto.IncentivoUSD,
                Scopus = dto.SCOPUS,
                WoSQ = dto.WoS_Q,
                EsciQ = dto.ESCI_Q,
                Ajg = dto.AJG,
                Cnrs = dto.CNRS,
                Abdc = dto.ABDC,
                WoSLatam = dto.WoS_LATAM
            };
            await _lcdRepo.UpdateAsync(lcd);
            return true;
        }

        public async Task<bool> EliminarLCDPorIssnAsync(string issn)
        {
            var issnObj = (await _issnRepo.GetAllAsync()).FirstOrDefault(x => x.Issn == issn);
            if (issnObj == null || !issnObj.IdRevista.HasValue) return false;
            var revista = await _revistaRepo.GetByIdAsync(issnObj.IdRevista.Value);
            if (revista == null) return false;
            revista.Estado = 0;
            await _revistaRepo.UpdateAsync(revista);
            return true;
        }
    }
}
