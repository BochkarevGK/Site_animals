using AnimalShelter.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("SqliteConnection");
		services.AddDbContext<AnimalShelterDbContext>(options => options.UseSqlite(connectionString));
		services.AddScoped<IAnimalShelterDbContext>(provider => provider.GetService<AnimalShelterDbContext>());
		return services;
	}
}