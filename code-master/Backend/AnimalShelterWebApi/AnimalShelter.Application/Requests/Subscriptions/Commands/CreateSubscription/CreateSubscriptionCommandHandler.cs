using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;

public sealed class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateSubscriptionCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateSubscriptionCommand,Guid> Members
	public async Task<Guid> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
	{
		var entity = new Subscription
		{
			Id = new Guid(),
			Email = request.Email
		};

		await _dbContext.Subscriptions.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
	#endregion

}