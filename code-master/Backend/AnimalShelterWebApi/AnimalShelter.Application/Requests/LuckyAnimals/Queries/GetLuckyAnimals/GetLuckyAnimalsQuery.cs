using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

public sealed record GetLuckyAnimalsQuery : IRequest<LuckyAnimalsVm>;