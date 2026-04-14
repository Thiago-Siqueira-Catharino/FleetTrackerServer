using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;
using FleetTracker.Contexts.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase;

public class NewAdminUseCase(UserManager<User> _userManager)
{
    public async Task Run(NewUserDto newUser)
    {
        Admin admin = new Admin
        {
            UserName = newUser.Name,
            Email = newUser.Email,
        };
        
        var result = await _userManager.CreateAsync(admin, newUser.Password);
        
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(admin, "Admin");

        else
        {
            throw new ApplicationException(result.Errors.First().Description);
        }
    }
}