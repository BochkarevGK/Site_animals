using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;

public sealed class CreateAnimalAvailabilityCommandHandler : IRequestHandler<CreateAnimalAvailabilityCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateAnimalAvailabilityCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateAnimalAvailabilityCommand,Guid> Members
	public async Task<Guid> Handle(CreateAnimalAvailabilityCommand request, CancellationToken cancellationToken)
	{
		var animalAvailability = new AnimalAvailability
		{
			Id = new Guid(),
			Name = request.Name
		};

		await _dbContext.AnimalAvailabilities.AddAsync(animalAvailability, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return animalAvailability.Id;
	}
	#endregion

}