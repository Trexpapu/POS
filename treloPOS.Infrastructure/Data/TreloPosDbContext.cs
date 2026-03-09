using Microsoft.EntityFrameworkCore;
using treloPOS.Domain.Entities;

namespace treloPOS.Infrastructure.Data;

public class TreloPosDbContext : DbContext
{
    public TreloPosDbContext(DbContextOptions<TreloPosDbContext> options) : base(options) { }

    public DbSet<Users> Users { get; set; }
    public DbSet<Organizations> Organizations { get; set; }
    public DbSet<Roles> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación: Users -> Organizations (muchos a uno)
        modelBuilder.Entity<Users>()
            .HasOne(u => u.Organization)
            .WithMany(o => o.Users)
            .HasForeignKey(u => u.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: Users -> Roles (muchos a uno)
        modelBuilder.Entity<Users>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índice único en el email del usuario
        modelBuilder.Entity<Users>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // ─── Catálogo de Roles (Seed Data) ───
        // Usamos GUIDs fijos para poder referenciarlos desde código
        var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Roles>().HasData(
            new Roles
            {
                Id = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000001"),
                Name = "Admin",
                Description = "Administrador de la organización. Acceso total al sistema.",
                Status = true,
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },
            new Roles
            {
                Id = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000002"),
                Name = "Cajero",
                Description = "Operador de caja. Puede realizar ventas y cobros.",
                Status = true,
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },
            new Roles
            {
                Id = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000003"),
                Name = "Supervisor",
                Description = "Supervisor de sucursal. Puede aprobar descuentos y ver reportes.",
                Status = true,
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },
            new Roles
            {
                Id = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000004"),
                Name = "Inventario",
                Description = "Encargado de inventario. Puede gestionar productos y stock.",
                Status = true,
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            }
        );
    }
}