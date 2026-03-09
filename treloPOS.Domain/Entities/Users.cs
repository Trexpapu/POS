namespace treloPOS.Domain.Entities;

public class Users
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // FK hacia la organización a la que pertenece
    public Guid OrganizationId { get; set; }
    public Organizations Organization { get; set; } = null!;

    // FK hacia el rol del usuario
    public Guid RoleId { get; set; }
    public Roles Role { get; set; } = null!;
}