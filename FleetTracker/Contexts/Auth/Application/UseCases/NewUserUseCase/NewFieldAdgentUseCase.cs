using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;
using FleetTracker.Contexts.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase;

public class NewFieldAdgentUseCase(UserManager<User> _userManager)
{
    public async Task Run(NewUserDto newUser)
    {
        FieldAgent fieldAgent = new FieldAgent
        {
            UserName = newUser.Name,
            Email = newUser.Email,
        };
        
        var result = await _userManager.CreateAsync(fieldAgent, newUser.Password);
        
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(fieldAgent, "FieldAgent");
        
        else
        {
            throw new ApplicationException(result.Errors.First().Description);
        }
    }
}