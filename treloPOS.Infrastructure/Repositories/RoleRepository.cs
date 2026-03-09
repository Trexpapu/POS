using Microsoft.EntityFrameworkCore;
using treloPOS.Application.Interfaces.Repositories;
using treloPOS.Domain.Entities;
using treloPOS.Infrastructure.Data;

namespace treloPOS.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly TreloPosDbContext _context;

    public RoleRepository(TreloPosDbContext context)
    {
        _context = context;
    }

    public async Task<Roles?> GetByNameAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<Roles> CreateAsync(Roles role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }
}
