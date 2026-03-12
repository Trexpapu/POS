using treloPOS.Application.DTOs.Identity;

namespace treloPOS.Application.Interfaces.Services.Identity;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}