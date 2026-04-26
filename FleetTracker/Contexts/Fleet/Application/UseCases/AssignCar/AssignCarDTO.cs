using FleetTracker.Contexts.Auth.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.AssignCar
{
    public class AssignCarDTO
    {
        public Driver DriverId { get; set; } //Id do Motorista é um objeto DocumentoCNH? Se for, não sei como chamar aqui para estar vinculado a um Driver
        public Guid CarId { get; set; } //Carro tem várias properties que podem ser consideradas IDs, como LicensePlate, TagUID e Id, peguei o ID simples
    }
}
