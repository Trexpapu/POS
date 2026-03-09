using Microsoft.AspNetCore.Mvc;
using treloPOS.Application.Interfaces.Security;

namespace treloPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
// ---> MIRA ESTO: El constructor ahora va directamente al lado del nombre de la clase <---
public class UsersController(IPasswordHasher passwordHasher) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult ProbarHash([FromBody] string passwordEnTextoPlano)
    {
        // Ya podemos usar "passwordHasher" directamente sin crear variables privadas _passwordHasher
        var hashGenerado = passwordHasher.HashPassword(passwordEnTextoPlano);
        
        return Ok(new 
        { 
            mensaje = "Contraseña encriptada con éxito", 
            hash = hashGenerado 
        });
    }
}