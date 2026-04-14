using FleetTracker.Domain.ValueObjects;

namespace FleetTracker.Contexts.Fleet.Domain;

public class Car
{
    public string TagUid { get; } //LEMBRETE: confirmar tipo de tag para criar um ValueObject próprio
    public string Model { get; set; }
    public LicensePlate Plate { get; private set; }

    public Car(string tagUid, string model, string plate, float averageConsumption)
    {
        TagUid = tagUid;
        Model = model;  
        Plate = new LicensePlate(plate);
    }
}