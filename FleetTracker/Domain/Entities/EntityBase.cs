namespace FleetTracker.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; }
    public DateTime createdAt { get; set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
        createdAt = DateTime.Now;
    }
}