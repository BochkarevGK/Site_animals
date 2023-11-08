using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain;
using AnimalShelter.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Persistence;

public class AnimalShelterDbContext : DbContext, IAnimalShelterDbContext
{

	public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options) : base(options)
	{

	}

	public DbSet<Animal> Animals { get; set; }
	public DbSet<AnimalAvailability> AnimalAvailabilities { get; set; }
	public DbSet<Event> Events { get; set; }
	public DbSet<Kind> Kinds { get; set; }
	public DbSet<LuckyAnimal> LuckyAnimals { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Subscription> Subscriptions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AnimalAvailabilityConfiguration());
		modelBuilder.ApplyConfiguration(new AnimalConfiguration());
		modelBuilder.ApplyConfiguration(new EventConfiguration());
		modelBuilder.ApplyConfiguration(new KindConfiguration());
		modelBuilder.ApplyConfiguration(new LuckyAnimalConfiguration());
		modelBuilder.ApplyConfiguration(new OrderConfiguration());
		modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}