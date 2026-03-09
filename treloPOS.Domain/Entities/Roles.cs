namespace treloPOS.Domain.Entities;

public class Roles
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navegación: un rol tiene muchos usuarios
    public ICollection<Users> Users { get; set; } = new List<Users>();
}