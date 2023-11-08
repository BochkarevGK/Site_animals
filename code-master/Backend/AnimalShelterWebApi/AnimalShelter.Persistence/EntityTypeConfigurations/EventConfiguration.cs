using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{

	#region IEntityTypeConfiguration<Event> Members
	public void Configure(EntityTypeBuilder<Event> builder)
	{
		builder.HasKey(e => e.Id);
		builder.HasIndex(e => e.Id).IsUnique();
		builder.Property(e => e.Id).ValueGeneratedOnAdd();

		builder.Property(e => e.PhotoUrl)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(e => e.Description)
			.IsRequired()
			.HasMaxLength(450);

		builder.Property(e => e.Link)
			.HasMaxLength(200);
	}
	#endregion

}