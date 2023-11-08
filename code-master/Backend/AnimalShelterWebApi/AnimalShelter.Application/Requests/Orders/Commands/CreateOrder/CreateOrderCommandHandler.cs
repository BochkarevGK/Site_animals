using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateOrderCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateOrderCommand,Guid> Members
	public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		var entity = new Order
		{
			Id = new Guid(),
			Name = request.Name,
			Phone = request.Phone,
			Email = request.Email,
			PlannedDate = request.PlannedDate,
			Comment = request.Comment,
			AnimalId = request.AnimalId
		};

		await _dbContext.Orders.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
	#endregion

}