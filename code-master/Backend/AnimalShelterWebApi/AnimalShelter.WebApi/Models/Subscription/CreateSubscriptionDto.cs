using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Subscription;

public class CreateSubscriptionDto : IMapWith<CreateSubscriptionCommand>
{
	public string Email { get; init; } = null!;

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateSubscriptionDto, CreateSubscriptionCommand>();
	}
}