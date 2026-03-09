using Microsoft.EntityFrameworkCore;
using treloPOS.Application.Interfaces.Repositories;
using treloPOS.Domain.Entities;
using treloPOS.Infrastructure.Data;

namespace treloPOS.Infrastructure.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly TreloPosDbContext _context;

    public OrganizationRepository(TreloPosDbContext context)
    {
        _context = context;
    }

    public async Task<Organizations> CreateAsync(Organizations organization)
    {
        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();
        return organization;
    }

    public async Task<Organizations?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations.FindAsync(id);
    }
}
