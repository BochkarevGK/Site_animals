using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;

public sealed record CreateSubscriptionCommand : IRequest<Guid>
{
	public string Email { get; init; } = null!;
}