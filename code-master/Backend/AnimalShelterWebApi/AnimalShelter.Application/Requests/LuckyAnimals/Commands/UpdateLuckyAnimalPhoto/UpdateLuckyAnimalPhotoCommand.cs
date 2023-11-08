using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimalPhoto;

public sealed record UpdateLuckyAnimalPhotoCommand : IRequest
{
	public Guid Id { get; init; }
	
	public string PhotoUrl { get; init; } = null!;
}