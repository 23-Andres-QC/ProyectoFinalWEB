using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/enviar-reporte")]
    public class EnvioCorreoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public EnvioCorreoController(IConfiguration config)
        {
            _config = config;
        }

        // POST: api/enviar-reporte
        [HttpPost]
        public async Task<IActionResult> EnviarReporte(
            [FromForm] IFormFile archivo,
            [FromForm] string correo,
            [FromForm] string formatoCorreo,
            [FromForm] string asunto = null,
            [FromForm] string cuerpo = null,
            [FromForm] string tipo = null, // tipo de reporte o consulta
            [FromForm] string nombreUsuario = null, // nombre del usuario solicitante
            [FromForm] string revista = null, // nombre o código de la revista
            [FromForm] string filtros = null // filtros aplicados (opcional)
        )
        {
            // Log de parámetros recibidos para depuración
            System.Console.WriteLine($"[EnvioCorreo] archivo: {archivo?.FileName}, correo: {correo}, asunto: {asunto}, cuerpo: {cuerpo}, formatoCorreo: {formatoCorreo}, tipo: {tipo}, nombreUsuario: {nombreUsuario}, revista: {revista}, filtros: {filtros}");

            if (archivo == null || archivo.Length == 0)
                return BadRequest(new { success = false, message = "Archivo no proporcionado" });
            if (string.IsNullOrWhiteSpace(correo))
                return BadRequest(new { success = false, message = "Correo destinatario requerido" });

            // Leer configuración SMTP desde appsettings.json
            var smtpSection = _config.GetSection("SMTP");
            var smtpHost = smtpSection.GetValue<string>("Host");
            var smtpPort = smtpSection.GetValue<int>("Port");
            var smtpUser = smtpSection.GetValue<string>("User");
            var smtpPass = smtpSection.GetValue<string>("Pass");
            var enableSsl = smtpSection.GetValue<bool>("EnableSsl");

            if (string.IsNullOrWhiteSpace(smtpHost) || string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPass) || smtpPort == 0)
            {
                return StatusCode(500, new { success = false, message = "Faltan datos de configuración SMTP. Verifica appsettings.json." });
            }

            // Generar asunto y cuerpo según formatoCorreo
            string asuntoFinal = asunto;
            string cuerpoFinal = cuerpo;
            string sistema = "<b>Sistema de Reportes VDI</b>";
            string fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!string.IsNullOrWhiteSpace(formatoCorreo))
            {
                if (formatoCorreo.ToLower().Contains("consulta"))
                {
                    // Formato 1: Consulta sobre ISSN o Lista Cerrada
                    asuntoFinal = $"📄 Consulta sobre revista – {nombreUsuario}";
                    cuerpoFinal = $@"
                        <div style='font-family:Arial,sans-serif;font-size:15px;'>
                        <h2 style='color:#2d6cdf;'>Consulta sobre revista</h2>
                        <p>Hola,</p>
                        <p>Se ha realizado una <b>consulta</b> sobre la revista con los siguientes detalles:</p>
                        <ul>
                            <li><b>Tipo de consulta:</b> {tipo}</li>
                            <li><b>Revista:</b> {revista}</li>
                            <li><b>Solicitante:</b> {nombreUsuario}</li>
                            <li><b>Fecha y hora:</b> {fecha}</li>
                        </ul>
                        <p>Se adjunta un archivo Excel con la información correspondiente.</p>
                        <br>
                        <p>Saludos,<br>{sistema}</p>
                        <hr>
                        <small>Este correo fue enviado automáticamente.</small>
                        </div>";
                }
                else if (formatoCorreo.ToLower().Contains("reporte"))
                {
                    // Formato 2: Reporte administrativo
                    asuntoFinal = $"📊 {tipo} generado – {nombreUsuario}";
                    cuerpoFinal = $@"
                        <div style='font-family:Arial,sans-serif;font-size:15px;'>
                        <h2 style='color:#2d6cdf;'>Reporte administrativo generado</h2>
                        <p>Hola,</p>
                        <p>Se ha generado el siguiente <b>reporte administrativo</b>:</p>
                        <ul>
                            <li><b>Tipo de reporte:</b> {tipo}</li>
                            <li><b>Filtros aplicados:</b> {(string.IsNullOrWhiteSpace(filtros) ? "Ninguno" : filtros)}</li>
                            <li><b>Fecha de generación:</b> {fecha}</li>
                            <li><b>Generado por:</b> {nombreUsuario}</li>
                        </ul>
                        <p>Puedes revisar el contenido en el archivo Excel adjunto.</p>
                        <br>
                        <p>Saludos,<br>{sistema}</p>
                        <hr>
                        <small>Este correo fue generado automáticamente por el sistema.</small>
                        </div>";
                }
            }

            var message = new MailMessage();
            message.From = new MailAddress(smtpUser); // Asignar remitente usando el usuario SMTP
            try
            {
                message.To.Add(correo);
            }
            catch (System.FormatException ex)
            {
                return BadRequest(new { success = false, message = $"Correo destinatario inválido: {ex.Message}" });
            }
            message.Subject = asuntoFinal;
            message.Body = cuerpoFinal;
            message.IsBodyHtml = true;

            // Adjuntar archivo
            try
            {
                using (var stream = archivo.OpenReadStream())
                {
                    message.Attachments.Add(new Attachment(stream, archivo.FileName));

                    using (var smtp = new SmtpClient(smtpHost, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                        smtp.EnableSsl = enableSsl;
                        try
                        {
                            await smtp.SendMailAsync(message);
                            return Ok(new { success = true, message = "Correo enviado correctamente" });
                        }
                        catch (SmtpException ex)
                        {
                            return StatusCode(500, new { success = false, message = $"Error al enviar correo: {ex.Message}", inner = ex.InnerException?.Message });
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error al adjuntar archivo o enviar correo: {ex.Message}", inner = ex.InnerException?.Message });
            }
        }
    }
}
