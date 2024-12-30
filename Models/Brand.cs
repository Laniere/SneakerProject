using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerServer.Models
{
  [PrimaryKey(nameof(BrandId))]
  public class Brand
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int BrandId { get; set; }
    public string Name { get; set; } = null!;
    private ICollection<Sneaker> _sneakers = null!;
    public ICollection<Sneaker> Sneakers => _sneakers ??= new HashSet<Sneaker>();
  }
}