using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

public sealed class GetKindsQueryHandler : IRequestHandler<GetKindsQuery, KindsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetKindsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetKindsQuery,KindVm> Members
	public async Task<KindsVm> Handle(GetKindsQuery request, CancellationToken cancellationToken)
	{
		var query = await _dbContext.Kinds
			.ProjectTo<KindDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		return new KindsVm(query);
	}
	#endregion

}