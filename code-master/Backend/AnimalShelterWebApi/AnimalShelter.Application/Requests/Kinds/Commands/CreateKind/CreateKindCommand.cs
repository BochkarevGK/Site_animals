using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;

public sealed record CreateKindCommand : IRequest<Guid>
{
	public string Name { get; init; } = null!;
}