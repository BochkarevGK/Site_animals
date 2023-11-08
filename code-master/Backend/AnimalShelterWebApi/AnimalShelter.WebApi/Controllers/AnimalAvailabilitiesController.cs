using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;
using AnimalShelter.WebApi.Models.AnimalAvailability;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class AnimalAvailabilitiesController : BaseController
{
	private readonly IMapper _mapper;

	public AnimalAvailabilitiesController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<AnimalAvailabilitiesVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetAnimalAvailabilitiesQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalAvailabilityDto dto)
	{
		var command = _mapper.Map<CreateAnimalAvailabilityCommand>(dto);
		var entityId = await sender.Send(command);
		return Ok(entityId);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		var command = new DeleteAnimalAvailabilityCommand
		{
			Id = id
		};

		await sender.Send(command);
		return NoContent();
	}
	
}