using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

public record GetSubscriptionsQuery : IRequest<SubscriptionsVm>;