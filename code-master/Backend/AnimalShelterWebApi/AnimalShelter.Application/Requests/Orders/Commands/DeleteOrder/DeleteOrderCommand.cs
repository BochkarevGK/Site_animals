using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderCommand : IRequest
{
	public Guid Id { get; init; }
}