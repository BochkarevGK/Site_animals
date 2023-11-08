namespace AnimalShelter.Domain;

public class Animal
{
	public Guid Id { get; set; }

	public string PhotoUrl { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string? Description { get; set; } = null!;

	public string? DescriptionExtra { get; set; } = null!;

	public string? History { get; set; } = null!;

	public DateTime AdmissionDate { get; set; }

	public float Height { get; set; }

	public float Weight { get; set; }

	// kind
	public Guid KindId { get; set; }

	public Kind Kind { get; set; } = null!;

	// availability
	public Guid AnimalAvailabilityId { get; set; }

	public AnimalAvailability AnimalAvailability { get; set; } = null!;

	// orders
	public ICollection<Order> Orders { get; set; } = null!;

	// lucky animal
	public LuckyAnimal LuckyAnimal { get; set; } = null!;
}