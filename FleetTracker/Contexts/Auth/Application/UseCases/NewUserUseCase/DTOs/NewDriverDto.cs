namespace FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;

public record NewDriverDto(
    string Name,
    string Email,
    string Password,
    string DocumentCnh
    );