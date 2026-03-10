using treloPOS.Domain.Entities;

namespace treloPOS.Application.Interfaces.Repositories.Organizations;

public interface IOrganizationRepository
{
    Task<Domain.Entities.Organizations> CreateAsync(Domain.Entities.Organizations organization);
    Task<Domain.Entities.Organizations?> GetByIdAsync(Guid id);
}
