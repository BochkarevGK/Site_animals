namespace AnimalShelter.Domain;

public class Event
{
	public Guid Id { get; set; }

	public string PhotoUrl { get; set; } = null!;

	public string Description { get; set; } = null!;

	public string? Link { get; set; }
}