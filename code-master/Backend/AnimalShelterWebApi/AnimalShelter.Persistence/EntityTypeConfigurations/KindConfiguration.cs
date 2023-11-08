using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class KindConfiguration : IEntityTypeConfiguration<Kind>
{

	#region IEntityTypeConfiguration<Kind> Members
	public void Configure(EntityTypeBuilder<Kind> builder)
	{
		builder.HasKey(k => k.Id);
		builder.HasIndex(k => k.Id).IsUnique();
		builder.Property(k => k.Id).ValueGeneratedOnAdd();

		builder.Property(k => k.Name)
			.IsRequired()
			.HasMaxLength(50);
	}
	#endregion

}