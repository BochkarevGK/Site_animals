using AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;
using AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimalPhoto;
using AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;
using AnimalShelter.WebApi.Models.LuckyAnimal;
using AnimalShelter.WebApi.Services.Upload;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[Route("api/[controller]")]
public class LuckyAnimalsController : BaseController
{
	private readonly IMapper _mapper;
	private readonly IUploadService _uploadService;

	public LuckyAnimalsController(ISender sender, IMapper mapper, IUploadService uploadService) : base(sender)
	{
		_mapper = mapper;
		_uploadService = uploadService;
	}
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<LuckyAnimalsVm>> GetAll(CancellationToken cancellationToken)
	{
		var query = new GetLuckyAnimalsQuery();
		var vm = await sender.Send(query, cancellationToken);
		return Ok(vm);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateLuckyAnimalsDto dto)
	{

		var command = _mapper.Map<CreateLuckyAnimalCommand>(dto);
		var entityId = await sender.Send(command);

		var folder = Path.Combine("images", "lucky_animals");
		var filePath = await _uploadService.SaveFileAsync(dto.PhotoBase64, entityId.ToString(), folder); 
		
		var updatePhotoCommand = new UpdateLuckyAnimalPhotoCommand()
		{
			Id = entityId,
			PhotoUrl = filePath
		};
		await sender.Send(updatePhotoCommand);

		return Ok(entityId);
	}
}