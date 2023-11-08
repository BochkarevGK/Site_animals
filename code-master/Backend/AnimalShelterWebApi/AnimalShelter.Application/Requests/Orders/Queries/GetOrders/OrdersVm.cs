namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

public sealed record OrdersVm(IList<OrderDto> Orders);