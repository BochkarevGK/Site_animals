using AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;
using AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;
using AnimalShelter.WebApi.Models.Subscription;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class SubscriptionsController : BaseController
{
	private readonly IMapper _mapper;

	public SubscriptionsController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<SubscriptionsVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetSubscriptionsQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateSubscriptionDto dto)
	{
		var command = _mapper.Map<CreateSubscriptionCommand>(dto);
		var entityId = await sender.Send(command);
		return Ok(entityId);
	}
}