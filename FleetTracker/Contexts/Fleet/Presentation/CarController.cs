using FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;
using Microsoft.AspNetCore.Mvc;
using FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;

namespace FleetTracker.Contexts.Fleet.Presentation;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly RegisterNewCarUseCase _registerNewCarUseCase;
    private readonly GetCarByIdUseCase _getCarByIdUseCase;

    public CarsController(RegisterNewCarUseCase registerNewCarUseCase, GetCarByIdUseCase getCarByIdUseCase)
    {
       _getCarByIdUseCase = getCarByIdUseCase;
       _registerNewCarUseCase = registerNewCarUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegisterCarDTO request)
    {
      
        try 
        {
            var car = await _registerNewCarUseCase.Run(request);
            
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
    public async Task<IActionResult> GetById(GetCarByIdDTO id)
    {
        var car = await _getCarByIdUseCase.Run(id);

        if (car == null)
            return NotFound("Veículo não encontrado em Night City.");

        return Ok(car);
    }
}