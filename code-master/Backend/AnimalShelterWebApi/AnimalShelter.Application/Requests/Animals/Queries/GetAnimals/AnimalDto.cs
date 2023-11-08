using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

public sealed class AnimalDto : IMapWith<Animal>
{
	public Guid Id { get; init; }

	public string PhotoUrl { get; init; } = null!;

	public string Name { get; init; } = null!;

	public string? Description { get; init; }

	public string? DescriptionExtra { get; init; }

	public string? History { get; init; }

	public DateTime AdmissionDate { get; init; }

	public float Height { get; init; }

	public float Weight { get; init; }

	// kind
	public Guid KindId { get; init; }

	// availability
	public Guid AnimalAvailabilityId { get; init; }

	#region IMapWith<Animal> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Animal, AnimalDto>();
	}
	#endregion

}