namespace SneakerServer.Context.EntityConfiguration;

public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
  public void Configure(EntityTypeBuilder<Brand> builder)
  {
    builder.Property(e => e.BrandId).ValueGeneratedOnAdd();

    builder.HasMany(e => e.Sneakers)
    .WithOne(e => e.Brand)
    .HasForeignKey(e => e.SneakerId)
    .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(
      new Brand { BrandId = 1, Name = "Adidas" },
      new Brand { BrandId = 2, Name = "New Balance" },
      new Brand { BrandId = 3, Name = "Saucony" },
      new Brand { BrandId = 4, Name = "Asics" },
      new Brand { BrandId = 5, Name = "Timberland" }
    );

    builder.Navigation(e => e.Sneakers)
      .UsePropertyAccessMode(PropertyAccessMode.Property);
  }
}