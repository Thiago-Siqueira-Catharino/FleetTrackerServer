using FleetTracker.Contexts.Telemetry.Application.UseCases.CreatePathUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetTracker.Contexts.Telemetry.Presentation;

[ApiController]
[Route("api/[controller]")]
public class PathController(CreatePathUseCase createPathUseCase) : ControllerBase
{
    [Authorize(Roles = "Driver")]
    [HttpPost]
    public async Task<IActionResult> StartPath(CreatePathDto dto)
    {
        await createPathUseCase.RunAsync(dto);
        return Ok();
    }
}