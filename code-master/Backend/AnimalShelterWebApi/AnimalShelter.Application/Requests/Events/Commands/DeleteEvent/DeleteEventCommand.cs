using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;

public sealed record DeleteEventCommand : IRequest
{
	public Guid Id { get; init; }
}