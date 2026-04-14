using FleetTracker.Contexts.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleetTracker.Contexts.Auth.Infrastructure.Persistance;

public class AuthDbContext : IdentityDbContext<User>
{
    public DbSet<Admin> Administrators { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<FieldAgent> FieldAgents { get; set; }
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
}