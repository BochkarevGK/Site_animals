namespace AnimalShelter.Domain;

public class LuckyAnimal
{
	public Guid Id { get; set; }

	public string PhotoUrl { get; set; } = null!;

	public string? Comment { get; set; }

	public DateTime AdoptionDate { get; set; }

	// animal
	public Guid AnimalId { get; set; }

	public Animal Animal { get; set; } = null!;
}