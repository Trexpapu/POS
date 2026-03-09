using treloPOS.Domain.Entities;

namespace treloPOS.Application.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<Roles?> GetByNameAsync(string name);
    Task<Roles> CreateAsync(Roles role);
}
