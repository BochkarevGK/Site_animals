using System.Reflection;
using AnimalShelter.Application;
using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Persistence;
using AnimalShelter.WebApi.Services.Upload;

// Logging

// Builder

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices();

// App
var app = builder.Build();
ConfigureApp();
app.Run();

void ConfigureServices()
{
	// Add services to the container
	builder.Services.AddPersistence(builder.Configuration);
	builder.Services.AddApplication();

	// Add UploadService
	builder.Services.AddScoped<IUploadService, UploadService>();

	// Add controllers
	builder.Services.AddControllers();

	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	// Add mapping
	builder.Services.AddAutoMapper(config =>
	{
		config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
		config.AddProfile(new AssemblyMappingProfile(typeof(IAnimalShelterDbContext).Assembly));
	});

	// Add CORS
	builder.Services.AddCors(options =>
	{
		options.AddPolicy("AllowAll", policy =>
		{
			policy.AllowAnyHeader();
			policy.AllowAnyMethod();
			policy.AllowAnyOrigin();
		});
	});
}

void ConfigureApp()
{
	// Configure the HTTP request pipeline.
	app.UseSwagger();
	app.UseSwaggerUI();

	// Initialize database
	using (var scope = app.Services.CreateScope())
	{
		var context = scope.ServiceProvider.GetRequiredService<AnimalShelterDbContext>();
		DbInitializer.Initialize(context);
	}

	app.UseStaticFiles();

	app.UseRouting();

	// app.UseHttpsRedirection();
	
	// app.UseAuthorization();

	app.MapControllers();

	app.UseCors("AllowAll");
}