namespace FleetTracker.Domain.Entities;

public class Car
{
    public Guid Id { get; }
    public string TagUid { get; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public List<Path> Paths { get; set; } = new List<Path>();

    public Car(string tagUid, string model, string plate, float averageConsumption)
    {
        Id = Guid.NewGuid();
        TagUid = tagUid;
        Model = model;  
        Plate = plate;
    }
}