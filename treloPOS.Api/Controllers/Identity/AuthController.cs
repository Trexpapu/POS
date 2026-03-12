using Microsoft.AspNetCore.Mvc;
using treloPOS.Application.DTOs.Identity;
using treloPOS.Application.Interfaces.Services.Identity;

namespace treloPOS.Api.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            // Le pasamos la petición al Servicio (Caso de Uso) que creaste
            var response = await authService.LoginAsync(request);
            
            // Si todo sale bien, devolvemos un 200 OK con el Token
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            // Si falla la contraseña o el correo, devolvemos un 401 Unauthorized
            return Unauthorized(new { error = ex.Message });
        }
    }
}