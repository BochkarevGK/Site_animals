using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;

public sealed record UpdateAnimalPhotoCommand : IRequest
{
	public Guid Id { get; init; }
	
	public string PhotoUrl { get; init; } = null!;
}