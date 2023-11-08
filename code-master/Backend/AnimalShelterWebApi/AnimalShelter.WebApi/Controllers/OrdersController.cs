using AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;
using AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;
using AnimalShelter.Application.Requests.Orders.Queries.GetOrders;
using AnimalShelter.WebApi.Models.Order;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class OrdersController : BaseController
{
	private readonly IMapper _mapper;

	public OrdersController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<OrdersVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetOrdersQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto dto)
	{
		var command = _mapper.Map<CreateOrderCommand>(dto);
		var entityId = await sender.Send(command);
		return Ok(entityId);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		var command = new DeleteOrderCommand
		{
			Id = id
		};

		await sender.Send(command);
		return NoContent();
	}
	
}