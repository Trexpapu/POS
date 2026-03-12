using treloPOS.Domain.Entities;
namespace treloPOS.Application.Interfaces.Security;
public interface IJwtProvider{

    string GenerateToken(Users user);
}