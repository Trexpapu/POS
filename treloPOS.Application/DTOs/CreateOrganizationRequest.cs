using System.ComponentModel.DataAnnotations;

namespace treloPOS.Application.DTOs;

public class CreateOrganizationRequest
{
    // Datos de la organización
    [Required(ErrorMessage = "El nombre de la organización es obligatorio.")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
    public string OrganizationName { get; set; } = string.Empty;

    // Datos del usuario administrador
    [Required(ErrorMessage = "El nombre del administrador es obligatorio.")]
    public string AdminName { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string AdminEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    public string AdminPassword { get; set; } = string.Empty;
}
