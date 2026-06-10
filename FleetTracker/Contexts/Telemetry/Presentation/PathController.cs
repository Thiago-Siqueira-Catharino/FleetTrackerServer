using FleetTracker.Contexts.Telemetry.Application.UseCases.CreatePathUseCase;
using FleetTracker.Contexts.Telemetry.Application.UseCases.ListPathByCarIdUseCase;
using FleetTracker.Contexts.Telemetry.Application.UseCases.ListPathsUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetTracker.Contexts.Telemetry.Presentation;

[ApiController]
[Route("api/[controller]")]
public class PathController(
    CreatePathUseCase createPathUseCase,
    ListPathByCarIdUseCase listPathByCarIdUseCase,
    ListPathsUseCase listPathsUseCase
    ) : ControllerBase
{
    [Authorize(Roles = "Driver")]
    [HttpPost]
    public async Task<IActionResult> StartPath(CreatePathDto dto)
    {
        return Ok(await createPathUseCase.RunAsync(dto));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("search/id={carId}")]
    public async Task<IActionResult> ListPathsByCarId(Guid carId)
    {
        return Ok(await listPathByCarIdUseCase.RunAsync(carId));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("search/")]
    public async Task<IActionResult> ListPaths()
    {
        return Ok(await listPathsUseCase.RunAsync());
    }
}