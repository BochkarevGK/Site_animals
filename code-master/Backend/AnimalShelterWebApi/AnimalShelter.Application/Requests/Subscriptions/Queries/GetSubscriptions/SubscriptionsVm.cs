namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

public sealed record SubscriptionsVm(IList<SubscriptionDto> Subscriptions);