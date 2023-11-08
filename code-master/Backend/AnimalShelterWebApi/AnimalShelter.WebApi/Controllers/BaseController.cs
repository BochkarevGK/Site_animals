using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
	protected readonly ISender sender;

	protected BaseController(ISender sender)
	{
		this.sender = sender;
	}
}