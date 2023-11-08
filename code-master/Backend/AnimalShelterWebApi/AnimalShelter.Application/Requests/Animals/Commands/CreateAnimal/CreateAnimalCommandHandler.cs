using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;

public sealed class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateAnimalCommand,Guid> Members
	public async Task<Guid> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
	{
		var animal = new Animal
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Name = request.Name,
			Description = request.Description,
			DescriptionExtra = request.DescriptionExtra,
			History = request.History,
			AdmissionDate = request.AdmissionDate,
			Height = request.Height,
			Weight = request.Weight,
			KindId = request.KindId,
			AnimalAvailabilityId = request.AnimalAvailabilityId
		};

		await _dbContext.Animals.AddAsync(animal, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return animal.Id;
	}
	#endregion

}