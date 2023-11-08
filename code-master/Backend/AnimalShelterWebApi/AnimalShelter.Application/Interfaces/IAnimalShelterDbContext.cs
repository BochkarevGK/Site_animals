using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Interfaces;

public interface IAnimalShelterDbContext
{
	DbSet<Animal> Animals { get; set; }
	DbSet<AnimalAvailability> AnimalAvailabilities { get; set; }
	DbSet<Event> Events { get; set; }
	DbSet<Kind> Kinds { get; set; }
	DbSet<LuckyAnimal> LuckyAnimals { get; set; }
	DbSet<Order> Orders { get; set; }
	DbSet<Subscription> Subscriptions { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}