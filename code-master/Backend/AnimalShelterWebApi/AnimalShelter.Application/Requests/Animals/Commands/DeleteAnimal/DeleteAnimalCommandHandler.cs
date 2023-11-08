using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;

public sealed class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteAnimalCommand> Members
	public async Task Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Animals.FindAsync(new object?[] {request.Id}, cancellationToken);

		if (entity == null) throw new NotFoundException(nameof(Animal), request.Id);

		_dbContext.Animals.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}