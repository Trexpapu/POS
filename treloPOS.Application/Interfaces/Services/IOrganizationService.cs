using treloPOS.Application.DTOs;

namespace treloPOS.Application.Interfaces.Services;

public interface IOrganizationService
{
    Task<CreateOrganizationResponse> CreateOrganizationWithAdminAsync(CreateOrganizationRequest request);
}
