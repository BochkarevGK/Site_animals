using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

public sealed class SubscriptionDto : IMapWith<Subscription>
{
	public Guid Id { get; init; }

	public string Email { get; init; } = null!;

	#region IMapWith<Subscription> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Subscription, SubscriptionDto>();
	}
	#endregion

}