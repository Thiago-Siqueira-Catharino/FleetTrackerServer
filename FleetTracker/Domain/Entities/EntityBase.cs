namespace FleetTracker.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
    }
}