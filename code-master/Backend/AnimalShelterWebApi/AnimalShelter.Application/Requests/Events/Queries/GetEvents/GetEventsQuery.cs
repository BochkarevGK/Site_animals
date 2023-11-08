using MediatR;

namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

public sealed record GetEventsQuery : IRequest<EventsVm>;