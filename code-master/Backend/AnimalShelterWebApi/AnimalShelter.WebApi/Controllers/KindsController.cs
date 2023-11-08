
using AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;
using AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;
using AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;
using AnimalShelter.WebApi.Models.Kind;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class KindsController : BaseController
{
	private readonly IMapper _mapper;

	public KindsController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<KindsVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetKindsQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateKindDto dto)
	{
		var command = _mapper.Map<CreateKindCommand>(dto);
		var entityId = await sender.Send(command);
		return Ok(entityId);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		var command = new DeleteKindCommand
		{
			Id = id
		};

		await sender.Send(command);
		return NoContent();
	}
}