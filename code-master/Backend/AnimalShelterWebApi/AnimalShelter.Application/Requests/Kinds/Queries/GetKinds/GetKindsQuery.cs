using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

public sealed record GetKindsQuery : IRequest<KindsVm>;