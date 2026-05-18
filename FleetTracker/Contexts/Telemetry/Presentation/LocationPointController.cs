using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetTracker.Contexts.Telemetry.Presentation;

[ApiController]
[Route("api/[controller]")]
public class LocationPointController (RegisterCarLocationUseCase useCase) : ControllerBase
{
    [Authorize(Roles = "Driver")]
    [HttpPost("location/update")]
    public async Task<IActionResult> UpdateLocation(RegisterCarLocationDTO dto)
    {
        await useCase.RunAsync(dto);
        return Ok();
    }
}