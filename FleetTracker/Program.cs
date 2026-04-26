using System.Text;
using FleetTracker.Contexts.Auth.Application.UseCases.LoginUseCase;
using FleetTracker.Contexts.Auth.Application.UseCases.NewUserUseCase;
using FleetTracker.Contexts.Auth.Domain.Entities;
using FleetTracker.Contexts.Auth.Domain.Repositories;
using FleetTracker.Contexts.Auth.Infrastructure.Persistance;
using FleetTracker.Contexts.Auth.Infrastructure.Repositories;
using FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using FleetTracker.Contexts.Fleet.Infrastructure.Persistance;
using FleetTracker.Contexts.Fleet.Infrastructure.Repositories;
using FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 1. Register the DbContext (The missing piece!)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "server=localhost;database=fleet_db;user=root;password=";

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<FleetDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Register your Repositories and UseCases (Dependency Injection)
//Auth DI
builder.Services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<NewAdminUseCase>();
builder.Services.AddScoped<NewDriverUseCase>();
builder.Services.AddScoped<NewFieldAdgentUseCase>();
builder.Services.AddScoped<LoginUseCase>();

//Fleet DI
builder.Services.AddScoped<RegisterNewCarUseCase>();
builder.Services.AddScoped<GetCarByIdUseCase>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<RegisterNewCarUseCase>();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();