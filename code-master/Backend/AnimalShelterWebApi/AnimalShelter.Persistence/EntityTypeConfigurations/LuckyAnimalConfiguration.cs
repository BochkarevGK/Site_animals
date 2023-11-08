using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class LuckyAnimalConfiguration : IEntityTypeConfiguration<LuckyAnimal>
{

	#region IEntityTypeConfiguration<LuckyAnimal> Members
	public void Configure(EntityTypeBuilder<LuckyAnimal> builder)
	{
		builder.HasKey(la => la.Id);
		builder.HasIndex(la => la.Id).IsUnique();
		builder.Property(la => la.Id).ValueGeneratedOnAdd();

		builder.Property(la => la.PhotoUrl)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(la => la.Comment)
			.HasMaxLength(450);

		builder.Property(la => la.AdoptionDate)
			.IsRequired();

		builder.HasIndex(la => la.AnimalId)
			.IsUnique();

		builder.HasOne(la => la.Animal)
			.WithOne(a => a.LuckyAnimal)
			.HasForeignKey<LuckyAnimal>(la => la.AnimalId)
			.OnDelete(DeleteBehavior.Cascade);
	}
	#endregion

}