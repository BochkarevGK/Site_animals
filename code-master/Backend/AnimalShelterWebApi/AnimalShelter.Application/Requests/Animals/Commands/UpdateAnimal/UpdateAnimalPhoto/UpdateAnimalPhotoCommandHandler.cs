using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;

public sealed class UpdateAnimalPhotoCommandHandler : IRequestHandler<UpdateAnimalPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateAnimalPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Handle(UpdateAnimalPhotoCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Animals.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
		
		if (entity == null)
		{
			throw new NotFoundException(nameof(Animal), request.Id);
		}
		
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
}