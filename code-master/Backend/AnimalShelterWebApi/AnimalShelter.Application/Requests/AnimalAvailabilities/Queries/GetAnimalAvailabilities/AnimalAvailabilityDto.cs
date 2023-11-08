using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

public sealed class AnimalAvailabilityDto : IMapWith<AnimalAvailability>
{
	public Guid Id { get; init; }

	public string Name { get; init; } = null!;

	#region IMapWith<AnimalAvailability> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<AnimalAvailability, AnimalAvailabilityDto>();
	}
	#endregion

}