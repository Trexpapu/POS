// Usings para la base de datos
using Microsoft.EntityFrameworkCore;
// Usings para repositorios (agrupados por dominio)
using treloPOS.Application.Interfaces.Repositories.Identity;
using treloPOS.Application.Interfaces.Repositories.Organizations;
using treloPOS.Application.Interfaces.Security;
using treloPOS.Application.Interfaces.Services.Identity;
using treloPOS.Application.Interfaces.Services.Organizations;
using treloPOS.Application.Services.Identity;
using treloPOS.Application.Services.Organizations;
using treloPOS.Infrastructure.Data;
using treloPOS.Infrastructure.Repositories.Identity;
using treloPOS.Infrastructure.Repositories.Organizations;
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

// Repositorios - Organizations
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

// Repositorios - Identity
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Servicios de aplicación - Organizations
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
// Token y Autenticación
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
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