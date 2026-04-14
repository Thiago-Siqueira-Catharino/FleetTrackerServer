using Microsoft.AspNetCore.Identity;

namespace FleetTracker.Contexts.Auth.Domain.Entities;

public class User : IdentityUser
{
    public string Name { get; set; }
}