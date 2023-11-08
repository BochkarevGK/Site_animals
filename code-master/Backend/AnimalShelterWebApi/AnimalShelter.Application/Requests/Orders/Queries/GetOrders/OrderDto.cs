using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

public sealed class OrderDto : IMapWith<Order>
{
	public Guid Id { get; init; }

	public string Name { get; init; } = null!;

	public string Phone { get; init; } = null!;

	public string Email { get; init; } = null!;

	public DateTime PlannedDate { get; init; }

	public string? Comment { get; init; }

	// animal
	public Guid AnimalId { get; init; }

	#region IMapWith<Order> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Order, OrderDto>();
	}
	#endregion

}