using AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;
using AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;
using AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;
using AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;
using AnimalShelter.WebApi.Models.Animal;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.WebApi.Services.Upload;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class AnimalsController : BaseController
{
	private readonly IMapper _mapper;
	private readonly IUploadService _uploadService;

	public AnimalsController(ISender sender, IMapper mapper, IUploadService uploadService) : base(sender)
	{
		_mapper = mapper;
		_uploadService = uploadService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<AnimalsVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetAnimalsQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalDto dto)
	{
		var command = _mapper.Map<CreateAnimalCommand>(dto);
		var entityId = await sender.Send(command);

		var folder = Path.Combine("images", "animals");
		var filePath = await _uploadService.SaveFileAsync(dto.PhotoBase64, entityId.ToString(), folder); 
		
		var updatePhotoCommand = new UpdateAnimalPhotoCommand
		{
			Id = entityId,
			PhotoUrl = filePath
		};
		await sender.Send(updatePhotoCommand);

		return Ok(entityId);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		var command = new DeleteAnimalCommand
		{
			Id = id
		};

		await sender.Send(command);
		return NoContent();
	}
}