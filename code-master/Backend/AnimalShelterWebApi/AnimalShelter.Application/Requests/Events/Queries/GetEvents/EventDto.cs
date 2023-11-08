using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

public sealed class EventDto : IMapWith<Event>
{
	public Guid Id { get; init; }

	public string PhotoUrl { get; init; } = null!;

	public string Description { get; init; } = null!;

	public string? Link { get; init; }

	#region IMapWith<Event> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Event, EventDto>();
	}
	#endregion

}