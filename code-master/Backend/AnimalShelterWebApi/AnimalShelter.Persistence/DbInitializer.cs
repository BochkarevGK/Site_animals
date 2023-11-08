namespace AnimalShelter.Persistence;

public static class DbInitializer
{
	public static void Initialize(AnimalShelterDbContext context)
	{
		context.Database.EnsureCreated();
	}
}