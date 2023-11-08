using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

public sealed class KindDto : IMapWith<Kind>
{
	public Guid Id { get; init; }

	public string Name { get; init; } = null!;

	#region IMapWith<Kind> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Kind, KindDto>();
	}
	#endregion

}