namespace AnimalShelter.Domain;

public class Subscription
{
	public Guid Id { get; set; }

	public string Email { get; set; } = null!;
}