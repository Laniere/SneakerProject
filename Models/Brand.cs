using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerServer.Models;
[PrimaryKey(nameof(BrandId))]
public class Brand
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int BrandId { get; set; }
  public string Name { get; set; } = null!;
  private ICollection<Sneaker> _sneakers = null!;
  public ICollection<Sneaker> Sneakers => _sneakers ??= new HashSet<Sneaker>();

}

#region EF Config
public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
  private static readonly string _localPath = @"Files\Brand.txt";
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
    if (!File.Exists(_localPath))
    {
      //Todo ADD LOG
      return [];
    }
    string[] lines = File.ReadAllLines(_localPath);
    HashSet<Brand> brands = [];
    //Index new op in .NET 9
    foreach (var (index, item) in lines.Index())
    {
      brands.Add(new Brand { BrandId = index, Name = item });
    }
    return brands;
  }
}
#endregion
