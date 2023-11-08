namespace AnimalShelter.Domain;

public class Kind
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	// animals
	public ICollection<Animal> Animals { get; set; } = null!;
}