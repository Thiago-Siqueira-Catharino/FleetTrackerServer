namespace FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;

public record NewUserDto(
    string Name,
    string Email,
    string Password
    );