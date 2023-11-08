using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

public sealed record GetAnimalsQuery : IRequest<AnimalsVm>;