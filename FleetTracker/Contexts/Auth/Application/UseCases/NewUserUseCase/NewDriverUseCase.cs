using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;
using FleetTracker.Contexts.Auth.Domain.Entities;
using FleetTracker.Contexts.Auth.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase;

public class NewDriverUseCase(UserManager<User> _userManager)
{ 
    public async Task Run(NewDriverDto newDriver)
    {
        Driver driver = new Driver
        {
            UserName = newDriver.Name, 
            Email = newDriver.Email, 
            DocumentCnh =  new DocumentCnh(newDriver.DocumentCnh)
        };
        
        var result = await _userManager.CreateAsync(driver, newDriver.Password);

        if (result.Succeeded)
            await _userManager.AddToRoleAsync(driver, "Driver");

        else
        {
            throw new ArgumentException(result.Errors.First().Description);
        }
    }
}