using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

public sealed record GetOrdersQuery : IRequest<OrdersVm>;