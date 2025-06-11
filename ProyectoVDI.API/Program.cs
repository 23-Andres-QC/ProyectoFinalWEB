using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.Services;
using ProyectoVDI.CORE.Infrastructure.Repositories;
using ProyectoVDI.CORE.Infrastructure.Shared;
using ProyectoVDI.Infrastructure.Data;
//using OfficeOpenXml; // Eliminar referencia directa

var builder = WebApplication.CreateBuilder(args);

// EPPlus 8+: No establecer la licencia por código, solo por configuración (appsettings.json)
// ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Eliminar esta línea

// Add services to the container.
 
var _config = builder.Configuration;
var _connectionstring = _config.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<vdiContext>(options =>
    options.UseSqlServer(_connectionstring)
);

// Register the DbContext with dependency injection

// add interface

// Repositorios
builder.Services.AddTransient<ICalificacionChatBotRepository, CalificacionChatBotRepository>();
builder.Services.AddTransient<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddTransient<IDetRegistroRevistaRepository, DetRegistroRevistaRepository>();
builder.Services.AddTransient<IIssnsRevistaRepository, IssnsRevistaRepository>();
builder.Services.AddTransient<IMetadatosRevistaIssnRepository, MetadatosRevistaIssnRepository>();
builder.Services.AddTransient<IPreguntasFrecuentesChatBotRepository, PreguntasFrecuentesChatBotRepository>();
builder.Services.AddTransient<IProfesoresAdmisRepository, ProfesoresAdmisRepository>();
builder.Services.AddTransient<IRegistroRevistasRepository, RegistroRevistasRepository>();
builder.Services.AddTransient<IRevistaListaCerradaRepository, RevistaListaCerradaRepository>();
builder.Services.AddTransient<IRevistaRepository, RevistaRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();

// Servicios
builder.Services.AddTransient<ICalificacionChatBotService, CalificacionChatBotService>();
builder.Services.AddTransient<ICategoriasService, CategoriasService>();
builder.Services.AddTransient<IPreguntasFrecuentesChatBotService, PreguntasFrecuentesChatBotService>();
builder.Services.AddTransient<IProfesoresAdmisService, ProfesoresAdmisService>();
builder.Services.AddTransient<IRolService, RolService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

// JWT Authentication
builder.Services.AddSharedInfrastructure(_config);
builder.Services.AddHttpClient(); // para usar HttpClient en los controladores

builder.Services.AddControllers();
builder.Services.AddCoreServices();

// Add Cors policy

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        var frontendUrl = _config.GetValue<string>("FrontendUrl");
        builder//WithOrigins(frontendUrl)
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});





// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.UseCors(); //use the default CORS policy

app.MapControllers();

app.Run();
