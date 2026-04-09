using Microsoft.AspNetCore.Mvc;
using FleetTracker.Application.Services;
using FleetTracker.Domain.Entities;
using FleetTracker.Domain.DTOs.Requests;

namespace FleetTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarDTO request)
    {
      
        try 
        {
            var car = await _carService.RegisterNewCar(request);
            
            if (car == null)
                return BadRequest("Não foi possível processar o cadastro do veículo.");

            return CreatedAtAction(nameof(GetById), new { id = car.TagUid }, car);
        }
        catch (ArgumentException ex)
        {
            
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var car = await _carService.GetCarById(id);

        if (car == null)
            return NotFound("Veículo não encontrado em Night City.");

        return Ok(car);
    }
}