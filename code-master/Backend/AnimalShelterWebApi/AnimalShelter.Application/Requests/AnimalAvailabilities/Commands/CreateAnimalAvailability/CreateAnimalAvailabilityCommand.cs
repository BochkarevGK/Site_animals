using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;

public sealed record CreateAnimalAvailabilityCommand : IRequest<Guid>
{
	public string Name { get; init; } = null!;
}