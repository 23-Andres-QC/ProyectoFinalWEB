using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoVDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly string _documentoPath;

        public GeminiController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiKey = configuration["GeminiSettings:ApiKey"]?.Trim('<', '>');
            _model = configuration["GeminiSettings:Model"];
            _documentoPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "ProyectoVDI.CORE", "Infrastructure", "Data", "documento.txt");
        }

        // api/gemini/ask
        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] string pregunta)
        {
            // Lee el documento base
            string documento = await System.IO.File.ReadAllTextAsync(_documentoPath, Encoding.UTF8);

            // Instrucciones fijas para el prompt
            var instrucciones = $@"Instrucciones: 
Responde únicamente con base en el texto anterior o lleva la respuesta al contexto directo del mismo. No incluyas en la respuesta frases como “en el texto”, “según el contenido”, “según el texto”, “de acuerdo con el texto” ni términos similares.

Si la pregunta está completamente fuera del contenido proporcionado, responde exactamente con este mensaje:
¡Hola! 😊 Por favor, formula una pregunta más clara sobre el VDI de la Universidad ESAN para poder ayudarte mejor 🙌..

La respuesta debe ser breve (máximo 50 palabras), clara, organizada y no debe incluir explicaciones innecesarias ni la palabra “resumen”
Pregunta del usuario: ""{pregunta}?""";

            // El prompt es el documento + instrucciones
            var prompt = documento + "\n\n" + instrucciones;

            var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent?key={_apiKey}";
            var requestBody = new
            {
                contents = new[] { new { parts = new[] { new { text = prompt } } } }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error calling Gemini API");

            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);
            var text = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return Ok(text);
        }
    }
}
