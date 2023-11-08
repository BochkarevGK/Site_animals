using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

public sealed class LuckyAnimalDto : IMapWith<LuckyAnimal>
{
	public Guid Id { get; init; }

	public string PhotoUrl { get; init; } = null!;

	public string? Comment { get; init; }

	public DateTime AdoptionDate { get; init; }
	
	public AnimalDto Animal { get; init; } = null!;

	#region IMapWith<LuckyAnimal> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<LuckyAnimal, LuckyAnimalDto>();
	}
	#endregion

}