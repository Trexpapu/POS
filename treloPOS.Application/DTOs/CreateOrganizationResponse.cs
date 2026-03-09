namespace treloPOS.Application.DTOs;

public class CreateOrganizationResponse
{
    public Guid OrganizationId { get; set; }
    public string OrganizationName { get; set; } = string.Empty;
    public Guid AdminUserId { get; set; }
    public string AdminEmail { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}
