namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

public sealed record AnimalsVm(IList<AnimalDto> Animals);