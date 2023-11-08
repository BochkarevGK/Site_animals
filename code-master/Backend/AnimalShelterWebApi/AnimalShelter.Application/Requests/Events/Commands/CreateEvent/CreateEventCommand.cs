using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.CreateEvent;

public sealed record CreateEventCommand : IRequest<Guid>
{
	public string PhotoUrl { get; init; } = string.Empty;

	public string Description { get; init; } = null!;

	public string? Link { get; init; }
}