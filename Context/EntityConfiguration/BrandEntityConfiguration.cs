
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
    builder.Navigation(e => e.Sneakers)
      .UsePropertyAccessMode(PropertyAccessMode.Property);

    builder.HasData(SetSeedingBrandFromTxt());
  }

  private static HashSet<Brand> SetSeedingBrandFromTxt()
  {
    HashSet<Brand> brands = [];
    String localPath = @"Files\Brand.txt";
    if (!File.Exists(localPath))
    {
      //Todo ADD LOG
      return brands;
    }
    String[] lines = File.ReadAllLines(localPath);
    int brandId = 0;
    foreach (String item in lines)
    {
      brandId++;
      brands.Add(new Brand { BrandId = brandId, Name = item });
    }
    return brands;
  }
}