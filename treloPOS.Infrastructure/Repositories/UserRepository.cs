using Microsoft.EntityFrameworkCore;
using treloPOS.Application.Interfaces.Repositories;
using treloPOS.Domain.Entities;
using treloPOS.Infrastructure.Data;

namespace treloPOS.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TreloPosDbContext _context;

    public UserRepository(TreloPosDbContext context)
    {
        _context = context;
    }

    public async Task<Users> CreateAsync(Users user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Users?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
