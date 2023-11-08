using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

public sealed class GetAnimalsQueryHandler : IRequestHandler<GetAnimalsQuery, AnimalsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetAnimalsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetAnimalsQuery,AnimalsVm> Members
	public async Task<AnimalsVm> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
	{
		var query = await _dbContext.Animals
			.ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);
		
		return new AnimalsVm(query);
	}
	#endregion

}