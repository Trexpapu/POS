using Microsoft.AspNetCore.Mvc;
using treloPOS.Application.DTOs;
using treloPOS.Application.Interfaces.Services;

namespace treloPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpPost("register")]
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
