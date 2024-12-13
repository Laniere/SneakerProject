namespace SneakerServer.Models
{
  [PrimaryKey(nameof(BrandId))]
  public class Brand
  {
    public int BrandId { get; set; }
    public string Name { get; set; } = null!;
    private ICollection<Sneaker> _sneakers = null!;
    public ICollection<Sneaker> Sneakers => _sneakers ??= new HashSet<Sneaker>();
  }
}