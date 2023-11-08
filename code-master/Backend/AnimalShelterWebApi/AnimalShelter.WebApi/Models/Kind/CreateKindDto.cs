using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Kind;

public class CreateKindDto : IMapWith<CreateKindCommand>
{
	public string Name { get; init; } = null!;

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateKindDto, CreateKindCommand>();
	}
}