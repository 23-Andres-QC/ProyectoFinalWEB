using System;

namespace ProyectoVDI.CORE.Core.DTOs
{

    // DTOs para LA ENTIDAD metadatosRevistaIssn, revista, issnsRevista, registroRevistas, detRegistroRevista
    public class RevistaCompletaDTO
    {
        // ----------- REVISTA ------------------
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; } // 'ISSN' o 'Lista Cerrada'
        public int Estado { get; set; }

        // ----------- LISTA DE ISSNs (puede ser vacía o nula) ------------------
        public List<string>? ListaIssns { get; set; }

        // ----------- METADATOS (solo si TipoLista es 'ISSN') ------------------
        public string? Scopus { get; set; }                      // 1
        public string? WoSQ { get; set; }                        // 2
        public int? WoSS { get; set; }                           // 3
        public string? WoSEsci { get; set; }                     // 4
        public string? EsciQ { get; set; }                       // 5

        public string? Ajg4star { get; set; }                    // 6
        public string? Ajg { get; set; }                         // 7
        public int? AjgS { get; set; }                           // 8
        public string? Cnrs { get; set; }                        // 9
        public int? CnrsS { get; set; }                          // 10

        public string? Abdc { get; set; }                        // 11
        public int? AbdcS { get; set; }                          // 12
        public string? AlMenosUnaLista { get; set; }             // 13
        public string? SoloUnaLista { get; set; }                // 14
        public string? Scielo { get; set; }                      // 15

        public string? WoSLatam { get; set; }                    // 16
        public string? Top50 { get; set; }                       // 17
        public int? N { get; set; }                              // 18
        public string? BeallsList { get; set; }                  // 19
        public string? Mdpi { get; set; }                        // 20

        public string? Insights { get; set; }                    // 21
        public int? AjgExiste { get; set; }                      // 22
        public int? CnrsExiste { get; set; }                     // 23
        public int? AbdcExiste { get; set; }                     // 24
        public int? WoSTopExiste { get; set; }                   // 25

        public int? WoSEsciExiste { get; set; }                  // 26
        public int? ScopusExiste { get; set; }                   // 27
        public int? SoloScieloExiste { get; set; }               // 28
        public int? Especial216b { get; set; }                   // 29
        public int? LatamSinEsciExiste { get; set; }             // 30

        public int? EsciScieloSinScopus { get; set; }            // 31
        public int? Multiple { get; set; }                       // 32
        public int? MultidisciplinaryWos { get; set; }           // 33
        public string? CoautoriaEsan { get; set; }               // 34
        public string? PosicionAutor { get; set; }               // 35

        public float? Jif { get; set; }                          // 36
        public string? Country { get; set; }                     // 37
        public int? MultyAlMenosUnaLista { get; set; }           // 38
        public int? MultidisciplinaryScopus { get; set; }        // 39
        public int? MultidisciplinaryWosOScopys { get; set; }    // 40

        // ----------- REGISTRO DE REVISTA ------------------
        public int IdUsuario { get; set; }
       

        // ----------- DETALLE DEL REGISTRO ------------------
        // Conectado con IdRevista e IdRegistro, no se requiere más dato aquí
    }


    public class RevistaListDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
    }

    public class RevistaDetailDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
        // Agrega aquí campos importantes adicionales si es necesario
    }

    public class RevistaCreateDTO
    {
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
    }

    public class RevistaUpdateDTO
    {
        public int IdRevista { get; set; }
        public string? Nombre { get; set; }
        public string? TipoLista { get; set; }
        public int? Estado { get; set; }
    }

    public class RevistaChangeEstadoDTO
    {
        public int IdRevista { get; set; }
        public int Estado { get; set; }
    }
}
