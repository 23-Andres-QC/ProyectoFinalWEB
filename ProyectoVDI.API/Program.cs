using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var _connectionstring = _config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<vdiContext>(options =>options.UseSqlServer(_connectionstring));
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
