using treloPOS.Application.DTOs;
using treloPOS.Application.Interfaces.Repositories;
using treloPOS.Application.Interfaces.Security;
using treloPOS.Application.Interfaces.Services;
using treloPOS.Domain.Constants;
using treloPOS.Domain.Entities;

namespace treloPOS.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public OrganizationService(
        IOrganizationRepository organizationRepository,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateOrganizationResponse> CreateOrganizationWithAdminAsync(CreateOrganizationRequest request)
    {
        // 1. Verificar que no exista un usuario con ese email
        var existingUser = await _userRepository.GetByEmailAsync(request.AdminEmail);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Ya existe un usuario con ese correo electrónico.");
        }

        // 2. Crear la organización
        var organization = new Organizations
        {
            Name = request.OrganizationName
        };
        await _organizationRepository.CreateAsync(organization);

        // 3. Crear el usuario administrador con el rol Admin del catálogo
        var adminUser = new Users
        {
            Name = request.AdminName,
            Email = request.AdminEmail,
            PasswordHash = _passwordHasher.HashPassword(request.AdminPassword),
            OrganizationId = organization.Id,
            RoleId = RoleCatalog.AdminId  // ← Usamos la constante del catálogo
        };
        await _userRepository.CreateAsync(adminUser);

        // 4. Devolver la respuesta
        return new CreateOrganizationResponse
        {
            OrganizationId = organization.Id,
            OrganizationName = organization.Name,
            AdminUserId = adminUser.Id,
            AdminEmail = adminUser.Email,
            RoleName = "Admin"
        };
    }
}
