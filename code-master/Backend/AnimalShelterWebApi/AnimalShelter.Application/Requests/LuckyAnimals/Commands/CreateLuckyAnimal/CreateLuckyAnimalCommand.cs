using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;

public sealed record CreateLuckyAnimalCommand : IRequest<Guid>
{

	public string PhotoUrl { get; init; } = string.Empty;

	public string? Comment { get; init; }

	public DateTime AdoptionDate { get; init; }

	// animal
	public Guid AnimalId { get; init; }
}