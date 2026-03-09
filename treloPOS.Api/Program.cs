// Usings que ya teníamos
// Usings para la base de datos
using Microsoft.EntityFrameworkCore;
// Usings para los repositorios e interfaces
using treloPOS.Application.Interfaces.Repositories;
using treloPOS.Application.Interfaces.Security;
using treloPOS.Application.Interfaces.Services;
using treloPOS.Application.Services;
using treloPOS.Infrastructure.Data;
using treloPOS.Infrastructure.Repositories;
using treloPOS.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Nuestro encriptador de contraseñas
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

// Base de datos con SQLite
builder.Services.AddDbContext<TreloPosDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Servicios de aplicación
builder.Services.AddScoped<IOrganizationService, OrganizationService>();

// ¡Todo se debe registrar antes de esta línea!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();