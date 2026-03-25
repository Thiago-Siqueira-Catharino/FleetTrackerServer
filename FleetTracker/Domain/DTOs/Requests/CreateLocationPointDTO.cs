namespace FleetTracker.Domain.DTOs.Requests;

public class CreateLocationPointDTO
{
    public DateTime timestamp { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public double fuelLevel { get; set; }

    public CreateLocationPointDTO(DateTime timestamp, double latitude, double longitude, double fuelLevel)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            {"timestamp", timestamp.ToString()},
            {"latitude", latitude.ToString()},
            {"longitude", longitude.ToString()},
            {"fuel level", fuelLevel.ToString()}
        };
        foreach (var parameter in parameters)
        {
            if (string.IsNullOrEmpty(parameter.Value))
                throw new ArgumentException($"{parameter.Key} must not be null or empty");
        }
        
        this.timestamp = timestamp;
        this.latitude = latitude;
        this.longitude = longitude;
        this.fuelLevel = fuelLevel;
    }
}