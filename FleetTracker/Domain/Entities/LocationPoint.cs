using FleetTracker.Domain.ValueObjects;

namespace FleetTracker.Domain.Entities;

public class LocationPoint :  EntityBase
{
    public DateTime timeStamp { get; private set; }
    public Coordinate coordinate  { get; private set; }
    public double fuelLevel { get; private set; } //Talvez criar um Value Object próprio? Não sei ainda

    public LocationPoint(DateTime timeStamp, Coordinate coordinate, double fuelLevel)
    {
        Dictionary<String, Object> parameters = new Dictionary<string, object>
        {
            { "Timestamp", timeStamp },
            { "Coordinate", coordinate},
            { "FuelLevel", fuelLevel}
        };
        foreach (var parameter in parameters)
        {
            if (parameter.Value == null)
                throw new ArgumentException($"{parameter.Key} must not be null");
        }
    }
}