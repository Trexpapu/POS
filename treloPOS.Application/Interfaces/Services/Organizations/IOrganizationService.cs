using treloPOS.Application.DTOs.Organizations;

namespace treloPOS.Application.Interfaces.Services.Organizations;

public interface IOrganizationService
{
    Task<CreateOrganizationResponse> CreateOrganizationWithAdminAsync(CreateOrganizationRequest request);
}
