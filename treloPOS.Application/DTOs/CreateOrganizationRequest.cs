namespace treloPOS.Application.DTOs;

public class CreateOrganizationRequest
{
    // Datos de la organización
    public string OrganizationName { get; set; } = string.Empty;

    // Datos del usuario administrador
    public string AdminName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public string AdminPassword { get; set; } = string.Empty;
}
