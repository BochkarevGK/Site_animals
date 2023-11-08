using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;

public sealed class CreateKindCommandHandler : IRequestHandler<CreateKindCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateKindCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateKindCommand,Guid> Members
	public async Task<Guid> Handle(CreateKindCommand request, CancellationToken cancellationToken)
	{
		var entity = new Kind
		{
			Id = new Guid(),
			Name = request.Name
		};

		await _dbContext.Kinds.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
	#endregion

}