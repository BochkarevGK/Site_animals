using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteEventCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteEventCommand> Members
	public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Events.FindAsync(new object?[] {request.Id}, cancellationToken);

		if (entity == null) throw new NotFoundException(nameof(Event), request.Id);

		_dbContext.Events.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}