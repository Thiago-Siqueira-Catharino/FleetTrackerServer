using FleetTracker.Contexts.Auth.Application.UseCases.LoginUseCase;
using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase;
using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FleetTracker.Contexts.Auth.Presentation;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    NewDriverUseCase registerDriver, 
    NewAdminUseCase registerAdmin, 
    NewFieldAdgentUseCase registerAgent, 
    LoginUseCase loginUseCase
    ) : ControllerBase
{
    [HttpPost("register/driver")]
    public async Task<IActionResult> RegisterDriver(NewDriverDto driverToRegister)
    {
        await registerDriver.Run(driverToRegister);
        return Ok();
    }
    
    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin(NewUserDto newUser)
    {
        await registerAdmin.Run(newUser);
        return Ok();
    }

    [HttpPost("register/fieldagent")]
    public async Task<IActionResult> RegisterFieldAgent(NewUserDto newUser)
    {
        await registerAgent.Run(newUser);
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        var token = await loginUseCase.Run(login);
        
        if  (token == null)
            return  Unauthorized();
        
        return Ok(token);
    }
}