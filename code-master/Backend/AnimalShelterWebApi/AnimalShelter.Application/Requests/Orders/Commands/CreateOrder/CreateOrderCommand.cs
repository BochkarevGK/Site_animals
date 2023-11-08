using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand : IRequest<Guid>
{

	public string Name { get; init; } = null!;

	public string Phone { get; init; } = null!;

	public string Email { get; init; } = null!;

	public DateTime PlannedDate { get; init; }

	public string? Comment { get; init; } = null!;

	// animal
	public Guid AnimalId { get; init; }
}