using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ProyectoVDI.CORE.Core.Services
{
    public class RevistaListaCerradaService : IRevistaListaCerradaService
    {
        private readonly IRevistaListaCerradaRepository _repository;
        public RevistaListaCerradaService(IRevistaListaCerradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RevistaListaCerradaListDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(item => new RevistaListaCerradaListDTO
            {
                IdRevista = item.IdRevista,
                Nombre = item.Nombre,
                Categoria = item.Categoria,
                Puntaje = item.Puntaje,
                IncentivoUsd = item.IncentivoUsd
            });
        }

        // Importa la lista cerrada desde un archivo Excel y actualiza o inserta según corresponda
        public async Task<bool> ImportarDesdeExcelAsync(byte[] archivoExcelBytes)
        {
            // No establecer licencia aquí, solo configuración en appsettings.json
            using (var stream = new MemoryStream(archivoExcelBytes))
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.First();
                int rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++) // Asume encabezado en la fila 1
                {
                    var nombre = worksheet.Cells[row, 1].Text;
                    var existente = await _repository.GetByNombreAsync(nombre);
                    var entity = new RevistaListaCerrada
                    {
                        Nombre = nombre,
                        Categoria = worksheet.Cells[row, 2].Text,
                        Puntaje = double.TryParse(worksheet.Cells[row, 3].Text, out var puntaje) ? puntaje : null,
                        IncentivoUsd = int.TryParse(worksheet.Cells[row, 4].Text, out var incentivo) ? incentivo : null,
                        Scopus = worksheet.Cells[row, 5].Text,
                        WoSQ = worksheet.Cells[row, 6].Text,
                        EsciQ = worksheet.Cells[row, 7].Text,
                        Ajg = worksheet.Cells[row, 8].Text,
                        Cnrs = worksheet.Cells[row, 9].Text,
                        Abdc = worksheet.Cells[row, 10].Text,
                        WoSLatam = worksheet.Cells[row, 11].Text
                    };
                    if (existente != null)
                    {
                        entity.IdRevista = existente.IdRevista;
                        await _repository.UpdateAsync(entity);
                    }
                    else
                    {
                        await _repository.CreateAsync(entity);
                    }
                }
            }
            return true;
        }

        // Importa la lista cerrada desde un array de objetos JSON y actualiza o inserta según corresponda
        public async Task<bool> ImportarDesdeListaAsync(IEnumerable<RevistaListaCerradaDetailDTO> revistas)
        {
            foreach (var dto in revistas)
            {
                var existente = await _repository.GetByNombreAsync(dto.Nombre);
                var entity = new RevistaListaCerrada
                {
                    Nombre = dto.Nombre,
                    Categoria = dto.Categoria,
                    Puntaje = dto.Puntaje,
                    IncentivoUsd = dto.IncentivoUsd,
                    Scopus = dto.Scopus,
                    WoSQ = dto.WoSQ,
                    EsciQ = dto.EsciQ,
                    Ajg = dto.Ajg,
                    Cnrs = dto.Cnrs,
                    Abdc = dto.Abdc,
                    WoSLatam = dto.WoSLatam
                };
                if (existente != null)
                {
                    entity.IdRevista = existente.IdRevista;
                    await _repository.UpdateAsync(entity);
                }
                else
                {
                    await _repository.CreateAsync(entity);
                }
            }
            return true;
        }
    }
}
