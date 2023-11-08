using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;
using AnimalShelter.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimalPhoto;

public sealed class UpdateLuckyAnimalPhotoCommandHandler : IRequestHandler<UpdateLuckyAnimalPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateLuckyAnimalPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Handle(UpdateLuckyAnimalPhotoCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.LuckyAnimals.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
		
		if (entity == null)
		{
			throw new NotFoundException(nameof(LuckyAnimal), request.Id);
		}
		
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}