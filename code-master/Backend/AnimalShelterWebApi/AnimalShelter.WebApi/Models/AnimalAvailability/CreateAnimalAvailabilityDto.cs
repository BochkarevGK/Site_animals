using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.AnimalAvailability;

public class CreateAnimalAvailabilityDto : IMapWith<CreateAnimalAvailabilityCommand>
{
	public string Name { get; init; } = null!;

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateAnimalAvailabilityDto, CreateAnimalAvailabilityCommand>();
	}
}