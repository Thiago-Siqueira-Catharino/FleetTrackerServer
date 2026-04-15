using System.Text;
using FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using FleetTracker.Contexts.Fleet.Infrastructure.Persistance;
using FleetTracker.Contexts.Fleet.Infrastructure.Repositories;
using FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 1. Register the DbContext (The missing piece!)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "server=localhost;database=fleet_db;user=root;password=";

builder.Services.AddDbContext<FleetDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2. Register your Repositories and UseCases (Dependency Injection)
builder.Services.AddScoped<RegisterNewCarUseCase>();
builder.Services.AddScoped<GetCarByIdUseCase>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<RegisterNewCarUseCase>();

builder.Services.AddOpenApi();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();