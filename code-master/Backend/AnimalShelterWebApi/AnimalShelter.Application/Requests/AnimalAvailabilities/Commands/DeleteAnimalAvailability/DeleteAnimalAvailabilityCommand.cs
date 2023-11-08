using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;

public sealed record DeleteAnimalAvailabilityCommand : IRequest
{
	public Guid Id { get; init; }
}