using Microsoft.AspNetCore.Mvc;
using treloPOS.Application.Interfaces.Security;

namespace treloPOS.Api.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IPasswordHasher passwordHasher) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult ProbarHash([FromBody] string passwordEnTextoPlano)
    {
        var hashGenerado = passwordHasher.HashPassword(passwordEnTextoPlano);

        return Ok(new
        {
            mensaje = "Contraseña encriptada con éxito",
            hash = hashGenerado
        });
    }
}
