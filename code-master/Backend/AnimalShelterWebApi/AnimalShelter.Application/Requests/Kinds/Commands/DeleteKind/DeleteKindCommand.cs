using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;

public sealed record DeleteKindCommand : IRequest
{
	public Guid Id { get; init; }
}