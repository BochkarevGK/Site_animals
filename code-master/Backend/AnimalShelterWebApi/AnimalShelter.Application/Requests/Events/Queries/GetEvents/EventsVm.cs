namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

public sealed record EventsVm(IList<EventDto> Events);