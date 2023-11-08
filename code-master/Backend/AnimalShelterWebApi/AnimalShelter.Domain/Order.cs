namespace AnimalShelter.Domain;

public class Order
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	public string Phone { get; set; } = null!;

	public string Email { get; set; } = null!;

	public DateTime PlannedDate { get; set; }

	public string? Comment { get; set; } = null!;

	// animal
	public Guid AnimalId { get; set; }

	public Animal Animal { get; set; } = null!;
}