using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;

public sealed record UpdateEventPhotoCommand : IRequest
{
	public Guid Id { get; init; }
	
	public string PhotoUrl { get; init; } = null!;
}