using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

public sealed class GetLuckyAnimalsQueryHandler : IRequestHandler<GetLuckyAnimalsQuery, LuckyAnimalsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetLuckyAnimalsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetLuckyAnimalsQuery,LuckyAnimalsVm> Members
	public async Task<LuckyAnimalsVm> Handle(GetLuckyAnimalsQuery request, CancellationToken cancellationToken)
	{
		var query = await _dbContext.LuckyAnimals
			.Include(a => a.Animal)
			.ProjectTo<LuckyAnimalDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);
		
		return new LuckyAnimalsVm(query);
	}
	#endregion

}