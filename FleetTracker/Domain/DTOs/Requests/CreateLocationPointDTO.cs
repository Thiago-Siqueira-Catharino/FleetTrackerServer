namespace FleetTracker.Domain.DTOs.Requests;

public class CreateCoodinateDTO
{
    public double latitude { get; set; }
    public double longitude { get; set; }

    public CreateCoodinateDTO(double latitude, double longitude)
    {
        if (String.IsNullOrEmpty(latitude.ToString()))
            throw new ArgumentException("latitude must not be null or empty");
        
        if (String.IsNullOrEmpty(longitude.ToString()))
            throw new ArgumentException("longitude must not be null or empty");
        
        this.latitude = latitude;
        this.longitude = longitude;
    }
}