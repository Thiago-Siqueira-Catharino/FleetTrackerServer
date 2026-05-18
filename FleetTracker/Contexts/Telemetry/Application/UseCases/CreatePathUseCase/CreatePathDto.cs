namespace FleetTracker.Contexts.Telemetry.Application.UseCases.CreatePathUseCase;

public record CreatePathDto
{
    public Guid carId { get; set; }
};