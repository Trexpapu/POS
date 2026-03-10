using Microsoft.EntityFrameworkCore;
using treloPOS.Application.Interfaces.Repositories.Organizations;
using treloPOS.Domain.Entities;
using treloPOS.Infrastructure.Data;

namespace treloPOS.Infrastructure.Repositories.Organizations;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly TreloPosDbContext _context;

    public OrganizationRepository(TreloPosDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Organizations> CreateAsync(Domain.Entities.Organizations organization)
    {
        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();
        return organization;
    }

    public async Task<Domain.Entities.Organizations?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations.FindAsync(id);
    }
}
