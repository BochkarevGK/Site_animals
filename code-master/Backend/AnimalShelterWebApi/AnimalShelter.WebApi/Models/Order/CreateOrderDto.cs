using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Order;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
	public string Name { get; init; } = null!;

	public string Phone { get; init; } = null!;

	public string Email { get; init; } = null!;

	public DateTime PlannedDate { get; init; }

	public string? Comment { get; init; } = null!;

	// animal
	public Guid AnimalId { get; init; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
	}
}