using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteOrderCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteOrderCommand> Members
	public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Orders.FindAsync(new object?[] {request.Id}, cancellationToken);

		if (entity == null) throw new NotFoundException(nameof(Order), request.Id);

		_dbContext.Orders.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}