namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;

public class GetCarByIdDTO
{
    public Guid value { get; set; }

    public GetCarByIdDTO(Guid id)
    {
        if(id == Guid.Empty)
            throw  new ArgumentException("id cannot be empty");
            
        value = id;
    }
}