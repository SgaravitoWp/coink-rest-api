using CoinkRestAPI.CORE.Interfaces;
using CoinkRestAPI.CORE.Services;
using CoinRestAPI.CORE.Services;
using CoinRestAPI.Infrastructure.Data.Repositories;

// Crear el builder de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agregar secretos de usuario a la configuración
builder.Configuration.AddUserSecrets<Program>(); 

// Configurar servicios
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construir la aplicación
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

// Ejecutar la aplicación
app.Run();