using AnimalShelter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{

	#region IEntityTypeConfiguration<Order> Members
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(o => o.Id);
		builder.HasIndex(o => o.Id).IsUnique();
		builder.Property(o => o.Id).ValueGeneratedOnAdd();

		builder.Property(o => o.Name)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(o => o.Phone)
			.IsRequired()
			.HasMaxLength(15);

		builder.Property(o => o.Email)
			.IsRequired()
			.HasMaxLength(256);

		builder.Property(o => o.PlannedDate)
			.IsRequired();

		builder.Property(o => o.Comment)
			.HasMaxLength(450);

		builder.HasOne(o => o.Animal)
			.WithMany(a => a.Orders)
			.HasForeignKey(o => o.AnimalId)
			.OnDelete(DeleteBehavior.Cascade);
	}
	#endregion

}