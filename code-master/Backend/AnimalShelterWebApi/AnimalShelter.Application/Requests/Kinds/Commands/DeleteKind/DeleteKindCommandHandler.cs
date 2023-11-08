using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;

public sealed class DeleteKindCommandHandler : IRequestHandler<DeleteKindCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteKindCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteKindCommand> Members
	public async Task Handle(DeleteKindCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Kinds.FindAsync(new object?[] {request.Id}, cancellationToken);

		if (entity == null) throw new NotFoundException(nameof(Kinds), request.Id);

		_dbContext.Kinds.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}