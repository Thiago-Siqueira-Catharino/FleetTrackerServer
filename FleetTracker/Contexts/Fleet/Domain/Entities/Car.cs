namespace FleetTracker.Contexts.Fleet.Domain.Entities;

public class Car
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime RemovedAt { get; private set; }
    public bool Active { get; private set; }
    public string TagUid { get; }
    public string Model { get; set; }
    public string Plate { get; set; }

    public Car(string tagUid, string model, string plate)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        TagUid = tagUid;
        Model = model;  
        Plate = plate;
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Remove()
    {
        Active = false;
        RemovedAt = DateTime.Now;
    }
}