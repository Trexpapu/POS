using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using treloPOS.Application.Interfaces.Security;
using treloPOS.Domain.Entities;

namespace treloPOS.Infrastructure.Security;

public class JwtProvider(IConfiguration configuration) : IJwtProvider
{
    public string GenerateToken(Users user)
    {
        // 1. Traemos las claves secretas desde el archivo de configuración
        var secretKey = configuration["JwtOptions:SecretKey"];
        var issuer = configuration["JwtOptions:Issuer"];
        var audience = configuration["JwtOptions:Audience"];

        // 2. Preparamos la llave criptográfica
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // 3. Metemos los datos del usuario dentro de la pulsera VIP (a esto se le llama "Claims")
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("name", user.Name),
            new Claim("organizationId", user.OrganizationId.ToString()),
            new Claim("roleId", user.RoleId.ToString())
        };

        // 4. Fabricamos el Token con una duración de 8 horas
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8), 
            signingCredentials: credentials);

        // 5. Devolvemos el token convertido en un string (texto)
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}