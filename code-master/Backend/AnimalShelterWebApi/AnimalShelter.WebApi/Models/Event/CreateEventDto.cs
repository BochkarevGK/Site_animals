using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Events.Commands.CreateEvent;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Event;

public class CreateEventDto : IMapWith<CreateEventCommand>
{
	public string PhotoBase64 { get; init; } = null!;

	public string Description { get; init; } = null!;

	public string? Link { get; init; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateEventDto, CreateEventCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
}