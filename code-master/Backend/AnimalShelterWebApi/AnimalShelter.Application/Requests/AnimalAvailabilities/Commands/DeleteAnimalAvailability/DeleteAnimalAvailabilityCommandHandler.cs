using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;

public sealed class DeleteAnimalAvailabilityCommandHandler : IRequestHandler<DeleteAnimalAvailabilityCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteAnimalAvailabilityCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteAnimalAvailabilityCommand> Members
	public async Task Handle(DeleteAnimalAvailabilityCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.AnimalAvailabilities.FindAsync(new object?[] {request.Id}, cancellationToken);

		if (entity == null) throw new NotFoundException(nameof(AnimalAvailability), request.Id);

		_dbContext.AnimalAvailabilities.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}