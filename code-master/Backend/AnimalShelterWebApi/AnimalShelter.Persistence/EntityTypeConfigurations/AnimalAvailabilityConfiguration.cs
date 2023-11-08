using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class AnimalAvailabilityConfiguration : IEntityTypeConfiguration<AnimalAvailability>
{

	#region IEntityTypeConfiguration<AnimalAvailability> Members
	public void Configure(EntityTypeBuilder<AnimalAvailability> builder)
	{
		builder.HasKey(aa => aa.Id);
		builder.HasIndex(aa => aa.Id).IsUnique();
		builder.Property(aa => aa.Id).ValueGeneratedOnAdd();

		builder.Property(aa => aa.Name)
			.IsRequired()
			.HasMaxLength(50);
	}
	#endregion

}