using BCrypt.Net;
using treloPOS.Application.Interfaces.Security;

namespace treloPOS.Infrastructure.Security;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string passwordText, string hashGuardado)
    {
        return BCrypt.Net.BCrypt.Verify(passwordText, hashGuardado);
    }
}