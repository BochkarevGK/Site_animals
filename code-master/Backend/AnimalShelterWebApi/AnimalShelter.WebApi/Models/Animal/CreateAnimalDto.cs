using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Animal;

public class CreateAnimalDto : IMapWith<CreateAnimalCommand>
{
	public string PhotoBase64 { get; init; } = null!;

	public string Name { get; init; } = null!;

	public string? Description { get; init; } = null!;

	public string? DescriptionExtra { get; init; } = null!;

	public string? History { get; init; } = null!;

	public DateTime AdmissionDate { get; init; }

	public float Height { get; init; }

	public float Weight { get; init; }

	// kind
	public Guid KindId { get; init; }

	// availability
	public Guid AnimalAvailabilityId { get; init; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateAnimalDto, CreateAnimalCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
}