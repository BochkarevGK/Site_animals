using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;

public sealed record DeleteAnimalCommand : IRequest
{
	public Guid Id { get; init; }
}