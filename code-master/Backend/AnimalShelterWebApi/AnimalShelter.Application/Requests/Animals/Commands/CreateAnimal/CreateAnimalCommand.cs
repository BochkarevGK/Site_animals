using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;

public sealed record CreateAnimalCommand : IRequest<Guid>
{
	public string PhotoUrl { get; init; } = string.Empty;

	public string Name { get; init; } = null!;

	public string? Description { get; init; }

	public string? DescriptionExtra { get; init; }

	public string? History { get; init; }

	public DateTime AdmissionDate { get; init; }

	public float Height { get; init; }

	public float Weight { get; init; }

	// kind
	public Guid KindId { get; init; }

	// availability
	public Guid AnimalAvailabilityId { get; init; }
}