using FleetTracker.Contexts.Telemetry.Application.UseCases.ListLocationPointByPathIdUseCase;
using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetTracker.Contexts.Telemetry.Presentation;

[ApiController]
[Route("api/[controller]")]
public class LocationPointController (
    RegisterCarLocationUseCase useCase,
    ListLocationPointByPathUseCase listLocationPointByPathUseCase
    ): ControllerBase
{
    [Authorize(Roles = "Driver")]
    [HttpPost("location/update")]
    public async Task<IActionResult> UpdateLocation(RegisterCarLocationDTO dto)
    {
        Console.WriteLine(dto.Latitude + " DEBUGGER MESSAGE " + dto.Longitude);
        await useCase.RunAsync(dto);
        return Ok();
    }

    [HttpGet("location/search/pathId={pathId}")]
    public async Task<IActionResult> SearchPathId(Guid pathId)
    {
        return Ok(await listLocationPointByPathUseCase.RunAsync(pathId));
    }
}