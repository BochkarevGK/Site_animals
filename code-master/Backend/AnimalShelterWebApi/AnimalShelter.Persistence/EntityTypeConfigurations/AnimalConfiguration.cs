using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{

	#region IEntityTypeConfiguration<Animal> Members
	public void Configure(EntityTypeBuilder<Animal> builder)
	{
		builder.HasKey(a => a.Id);
		builder.HasIndex(a => a.Id);
		builder.Property(a => a.Id).ValueGeneratedOnAdd();

		builder.Property(a => a.PhotoUrl)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(a => a.Name).IsRequired()
			.HasMaxLength(50);

		builder.Property(a => a.Description)
			.HasMaxLength(450);

		builder.Property(a => a.DescriptionExtra)
			.HasMaxLength(450);

		builder.Property(a => a.History)
			.HasMaxLength(450);

		builder.Property(a => a.AdmissionDate)
			.IsRequired();

		builder.Property(a => a.Height)
			.IsRequired();

		builder.Property(a => a.Weight)
			.IsRequired();

		builder.HasOne(a => a.Kind)
			.WithMany(k => k.Animals)
			.HasForeignKey(a => a.KindId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(a => a.AnimalAvailability)
			.WithMany(aa => aa.Animals)
			.HasForeignKey(a => a.AnimalAvailabilityId)
			.OnDelete(DeleteBehavior.Cascade);
	}
	#endregion

}