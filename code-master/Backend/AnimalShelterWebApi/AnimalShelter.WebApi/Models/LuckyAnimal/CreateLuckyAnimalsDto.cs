using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.LuckyAnimal;

public class CreateLuckyAnimalsDto : IMapWith<CreateLuckyAnimalCommand>
{
	public string PhotoBase64 { get; init; } = null!;

	public string? Comment { get; init; }

	public DateTime AdoptionDate { get; init; }

	// animal
	public Guid AnimalId { get; init; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateLuckyAnimalsDto, CreateLuckyAnimalCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
}