using treloPOS.Domain.Entities;

namespace treloPOS.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<Users> CreateAsync(Users user);
    Task<Users?> GetByEmailAsync(string email);
}
