using FleetTracker.Contexts.Auth.Domain.ValueObjects;

namespace FleetTracker.Contexts.Auth.Domain.Entities;

public class Driver :  User
{
    public DocumentCnh? DocumentCnh { get; set; }
}