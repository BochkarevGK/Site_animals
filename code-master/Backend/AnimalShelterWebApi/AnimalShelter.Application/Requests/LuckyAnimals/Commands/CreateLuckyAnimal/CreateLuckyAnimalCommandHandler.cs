using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;

public sealed class CreateLuckyAnimalCommandHandler : IRequestHandler<CreateLuckyAnimalCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateLuckyAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateLuckyAnimalCommand,Guid> Members
	public async Task<Guid> Handle(CreateLuckyAnimalCommand request, CancellationToken cancellationToken)
	{
		var entity = new LuckyAnimal
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Comment = request.Comment,
			AdoptionDate = request.AdoptionDate,
			AnimalId = request.AnimalId
		};

		await _dbContext.LuckyAnimals.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
	#endregion

}