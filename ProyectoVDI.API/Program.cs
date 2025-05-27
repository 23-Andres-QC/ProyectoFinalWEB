using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Core.Services;
using ProyectoVDI.CORE.Infrastructure.Data;
using ProyectoVDI.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var _connectionstring = _config.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<vdiContext>(options =>
    options.UseSqlServer(_connectionstring)
);

// Register the DbContext with dependency injection


// add interface

builder.Services.AddTransient<IAutoriaRepository, AutoriaRepository>();
builder.Services.AddTransient<ICalificacionChatBotRepository, CalificacionChatBotRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IDetRegistroISSNRepository, DetRegistroISSNRepository>();
builder.Services.AddTransient<IEditorialRepository, EditorialRepository>();
builder.Services.AddTransient<IEvaluacionesRepository, EvaluacionesRepository>();
builder.Services.AddTransient<IPreguntasFrecuentesChatBotRepository, PreguntasFrecuentesChatBotRepository>();
builder.Services.AddTransient<IPresenciaEnListasRepository, PresenciaEnListasRepository>();
builder.Services.AddTransient<IProfesoresRepository, ProfesoresRepository>();
builder.Services.AddTransient<IRegistroISSNRepository, RegistroISSNRepository>();
builder.Services.AddTransient<IRevistaRepository, RevistaRepository>();
builder.Services.AddTransient<IRevistasIndexacionRepository, RevistasIndexacionRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();


builder.Services.AddTransient<IAutoriaService, AutoriaService>();
builder.Services.AddTransient<ICalificacionChatBotService, CalificacionChatBotService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IDetRegistroIssnService, DetRegistroIssnService>();
builder.Services.AddTransient<IEditorialService, EditorialService>();
builder.Services.AddTransient<IEvaluacionesService, EvaluacionesService>();
builder.Services.AddTransient<IPreguntasFrecuentesChatBotService, PreguntasFrecuentesChatBotService>();
builder.Services.AddTransient<IPresenciaEnListasService, PresenciaEnListasService>();
builder.Services.AddTransient<IProfesoresService, ProfesoresService>();
builder.Services.AddTransient<IRevistaService, RevistaService>();
builder.Services.AddTransient<IRevistaIndexacionService, RevistaIndexacionService>();
builder.Services.AddTransient<IRegistroIssnService, RegistroIssnService>();
builder.Services.AddTransient<IRolService,RolService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IRegistroIssnService, RegistroIssnService>();


builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
