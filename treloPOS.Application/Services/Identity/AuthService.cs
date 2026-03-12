using treloPOS.Application.DTOs.Identity;
using treloPOS.Application.Interfaces.Repositories.Identity;
using treloPOS.Application.Interfaces.Security;
using treloPOS.Application.Interfaces.Services.Identity;

namespace treloPOS.Application.Services.Identity;

public class AuthService (
    IUserRepository userRepository, 
    IPasswordHasher passwordHasher, 
    IJwtProvider jwtProvider
) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request){
        //1. buscamos al usuario en la base de datos
        var user = await userRepository.GetByEmailAsync(request.Email);
        // 2. Si no existe o la contraseña no hace match con el Hash, lo rebotamos
        // ✅ CORRECTO: Primero la contraseña que viene del Request, y luego el Hash de la BD
        if (user == null || !passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Credenciales inválidas.");
        }

        //3 si es el pedimos que fabriquen el token 
        var token = jwtProvider.GenerateToken(user);
        //4 se lo damos
        return new LoginResponse{
            Token = token, 
            UserName = user.Name,
            OrganizationName = user.Organization.Name,
            RoleName = user.Role.Name,
            UserId = user.Id,
            OrganizationId = user.OrganizationId,
            RoleId = user.RoleId
        };
    }
    
}