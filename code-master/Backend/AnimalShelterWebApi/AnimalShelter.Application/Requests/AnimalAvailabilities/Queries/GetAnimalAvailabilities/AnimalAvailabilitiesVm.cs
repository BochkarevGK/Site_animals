﻿namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

public sealed record AnimalAvailabilitiesVm( IList<AnimalAvailabilityDto> AnimalAvailabilities);