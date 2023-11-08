using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

public sealed record GetAnimalAvailabilitiesQuery : IRequest<AnimalAvailabilitiesVm>;