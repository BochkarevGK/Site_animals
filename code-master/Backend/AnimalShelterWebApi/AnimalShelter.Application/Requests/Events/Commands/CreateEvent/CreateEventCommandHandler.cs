using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.CreateEvent;

public sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateEventCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateEventCommand,Guid> Members
	public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
	{
		var entity = new Event
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Description = request.Description,
			Link = request.Link
		};

		await _dbContext.Events.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
	#endregion

}