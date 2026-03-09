using treloPOS.Domain.Entities;

namespace treloPOS.Application.Interfaces.Repositories;

public interface IOrganizationRepository
{
    Task<Organizations> CreateAsync(Organizations organization);
    Task<Organizations?> GetByIdAsync(Guid id);
}
