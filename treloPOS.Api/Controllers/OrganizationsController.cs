using Microsoft.AspNetCore.Mvc;
using treloPOS.Application.DTOs;
using treloPOS.Application.Interfaces.Services;

namespace treloPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    /// <summary>
    /// Registra una nueva organización junto con su usuario administrador.
    /// </summary>
    /// <param name="request">Datos de la organización y del administrador.</param>
    /// <returns>La organización y el administrador creados.</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(CreateOrganizationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateOrganizationRequest request)
    {
        try
        {
            var result = await _organizationService.CreateOrganizationWithAdminAsync(request);
            return Ok(new
            {
                mensaje = "Organización y administrador creados exitosamente",
                data = result
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
