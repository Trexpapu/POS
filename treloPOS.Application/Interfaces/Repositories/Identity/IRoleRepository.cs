using treloPOS.Domain.Entities;

namespace treloPOS.Application.Interfaces.Repositories.Identity;

public interface IRoleRepository
{
    Task<Roles?> GetByNameAsync(string name);
    Task<Roles> CreateAsync(Roles role);
}
