namespace treloPOS.Application.Interfaces.Security;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string passwordText, string hashGuardado);
}