using FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;
using Microsoft.AspNetCore.Mvc;
using FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;
using FleetTracker.Contexts.Fleet.Application.UseCases.GetCarLocationHistory;
using FleetTracker.Contexts.Fleet.Application.UseCases.ListCars;

namespace FleetTracker.Contexts.Fleet.Presentation;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly RegisterNewCarUseCase _registerNewCarUseCase;
    private readonly GetCarByIdUseCase _getCarByIdUseCase;
    private readonly GetCarLocationHistoryUseCase _getCarLocationHistoryUseCase;
    private readonly ListCarsUseCase _listCarsUseCase;

    public CarController(
        RegisterNewCarUseCase registerNewCarUseCase, 
        GetCarByIdUseCase getCarByIdUseCase, 
        GetCarLocationHistoryUseCase getCarLocationHistoryUseCase,
        ListCarsUseCase listCarsUseCase
        )
    {
       _getCarByIdUseCase = getCarByIdUseCase;
       _registerNewCarUseCase = registerNewCarUseCase;
       _getCarLocationHistoryUseCase = getCarLocationHistoryUseCase;
       _listCarsUseCase = listCarsUseCase;
    }
    
    [HttpPost("Cadastrar")]
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

    [HttpGet("Buscar")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _listCarsUseCase.RunAsync());
    }
    
    [HttpGet("Buscar/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = new GetCarByIdDTO(id);
        var car = await _getCarByIdUseCase.Run(dto);

        if (car == null)
            return NotFound("Veículo não encontrado em Night City.");

        return Ok(car);
    }

    [HttpGet("{id}/rotas")]
    public async Task<IActionResult> GetPath([FromRoute] Guid id, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var dto = new GetCarLocationHistoryDTO
        {
            CarId = id,
            StartDate = startDate,
            EndDate = endDate
        };

        var paths = await _getCarLocationHistoryUseCase.ExecuteAsync(dto);

        if (paths == null || !paths.Any())
        {
            return NotFound("Nenhuma rota encontrada para este veículo no período especificado.");
        }

        return Ok(paths);
    }
}