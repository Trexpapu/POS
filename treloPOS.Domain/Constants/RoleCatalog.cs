namespace treloPOS.Domain.Constants;

/// <summary>
/// Catálogo de IDs de roles predefinidos.
/// Estos GUIDs coinciden con el seed data en el DbContext.
/// </summary>
public static class RoleCatalog
{
    public static readonly Guid AdminId = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000001");
    public static readonly Guid CajeroId = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000002");
    public static readonly Guid SupervisorId = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000003");
    public static readonly Guid InventarioId = Guid.Parse("a1b2c3d4-0001-0001-0001-000000000004");
}
