using FleetTracker.Contexts.Telemetry.Domain.ValueObjects;
using FleetTracker.Common.Entities;

namespace FleetTracker.Contexts.Telemetry.Domain.Entities;

public class LocationPoint :  EntityBase
{
    public Path path   { get; set; }
    public Guid pathId { get; set; }
    public DateTime timeStamp { get; set; }
    public Coordinate coordinate  { get; set; }
    public double fuelLevel { get; set; } //Talvez criar um Value Object pr�prio? N�o sei ainda
    public double speed { get; set; }

    public LocationPoint()
    {
    }
    public LocationPoint(DateTime timeStamp, Coordinate coordinate, double fuelLevel, double speed)
    {
        Dictionary<String, Object> parameters = new Dictionary<string, object>
        {
            { "Timestamp", timeStamp },
            { "Coordinate", coordinate },
            { "Fuel level", fuelLevel },
            { "Speed", speed}
        };
        foreach (var parameter in parameters)
        {
            if (parameter.Value == null)
                throw new ArgumentException($"{parameter.Key} must not be null");
        }
        
        this.timeStamp = timeStamp;
        this.coordinate = coordinate;
        this.fuelLevel = fuelLevel;
        this.speed = speed;
    }

    public void SetPath(Path path)
    {
        if (path == null ||  path.Id == Guid.Empty)
            throw new ArgumentException("Invalid path");
        
        this.path = path;
        pathId = path.Id;
    }
}