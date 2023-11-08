using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;
using AnimalShelter.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;

public sealed class UpdateEventPhotoCommandHandler : IRequestHandler<UpdateEventPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateEventPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Handle(UpdateEventPhotoCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Events.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
		
		if (entity == null)
		{
			throw new NotFoundException(nameof(Event), request.Id);
		}
		
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}